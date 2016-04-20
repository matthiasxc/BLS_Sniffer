using BLS_API_Portable.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using BLS_API_Portable.Common;
using BLS_API_Portable.LocalUnemployment;
using BLS_API_Portable.National.CPS;
using BLS_API_Portable.CommonTypes;

namespace BLS_API_Portable.Services
{
    public class BlsService
    {
        // Use of the BLS API is described here:
        //   http://www.bls.gov/developers/api_signature.htm
        protected string SeriesBase = "http://api.bls.gov/publicAPI/v1/timeseries/data/";
        
        public BlsService() { }


        public async Task<List<RegionSeries>> GetAllLocalEmployment(int yearStart, int yearEnd)
        {
            List<State> allStates = States.AllStatesAndTerritoriesLA();
            var seriesResult = await GetLocalUnemployment(allStates, yearStart, yearEnd); 
            List<RegionSeries> returnSeries = new List<RegionSeries>();
            Dictionary<string, RegionSeries> sortSeries = new Dictionary<string, RegionSeries>();
            LocalUnemploymentParser lup = new LocalUnemploymentParser();

            foreach (Series s in seriesResult)
            {
                BlsSeries newSeries = new BlsSeries(s);
                newSeries.Params = lup.ParseSeriesID(newSeries.seriesID);
                string regionString = States.Dictionary[newSeries.Params.Region].Description;
                if (!sortSeries.ContainsKey(regionString))
                {
                    sortSeries[regionString] = new RegionSeries() { RegionName = regionString };

                }

                if (newSeries.Params.Measure == EmploymentMeasure.Employment)
                    sortSeries[regionString].Employment = newSeries;
                else if (newSeries.Params.Measure == EmploymentMeasure.Unemployment)
                    sortSeries[regionString].Unemployment = newSeries;
                else if (newSeries.Params.Measure == EmploymentMeasure.UnemploymentRate)
                    sortSeries[regionString].UnemploymentRate = newSeries;
                else if (newSeries.Params.Measure == EmploymentMeasure.LaborForce)
                    sortSeries[regionString].LaborForce = newSeries;
            }

            foreach (KeyValuePair<string, RegionSeries> kvp in sortSeries)
                returnSeries.Add(kvp.Value);

            var sortedSeries = from series in returnSeries
                               orderby series.RegionName ascending
                               select series;

            return sortedSeries.ToList();
        }

        public async Task<List<Series>> GetLocalUnemployment(List<State> states, int yearStart, int yearEnd)
        {
            List<string> listOfSeries = new List<string>();
            LocalUnemploymentParser lup = new LocalUnemploymentParser();
            
            foreach(State s in states)
            {
                listOfSeries.Add(lup.GetStateSeriesID(s, EmploymentMeasure.LaborForce, CommonTypes.Adjustment.Seasonal));
                listOfSeries.Add(lup.GetStateSeriesID(s, EmploymentMeasure.Employment, CommonTypes.Adjustment.Seasonal));
                listOfSeries.Add(lup.GetStateSeriesID(s, EmploymentMeasure.Unemployment, CommonTypes.Adjustment.Seasonal));
            }

            var results = await GetBlsSeries(listOfSeries, yearStart, yearEnd);

            return results;

        }

        public async Task<List<Series>> GetAllCPSData(int yearStart, int yearEnd)
        {
            List<string> listOfSeries = new List<string>();
            foreach (KeyValuePair<CPSType, BlsField> kvp in CPSDataTypes.Dictionary)
            {
                listOfSeries.Add(kvp.Value.Code);
            }
            var results = await GetBlsSeries(listOfSeries, yearStart, yearEnd);
            return results;
        }
        
        public async Task<List<Series>> GetBlsSeries(List<string> seriesIDs)
        {
            var result = await GetBlsSeries(seriesIDs, 0, 0);
            return result;
        }

        public async Task<List<Series>> GetBlsSeries(List<string> seriesIDs, int startYear, int endYear)
        {
            List<List<string>> seriesLists = new List<List<string>>();
            // The BLS API only handles 25 series per request, so we need to break down the requests
            //  multiples of 25.
            List<string> holderList = new List<string>();
            foreach(string s in seriesIDs)
            {
                if (holderList.Count == 25){
                    seriesLists.Add(holderList);
                    holderList = new List<string>();
                }

                holderList.Add(s);
            }
            seriesLists.Add(holderList);

            try
            {
                var httpClient = new HttpClient();
                List<Series> completeSeries = new List<Series>();
                foreach(List<string> seriesL in seriesLists)
                {
                    string postString = ParseToBlsPostString(seriesL, startYear, endYear);

                    StringContent postContent = new StringContent(postString, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(SeriesBase, postContent);
                    response.EnsureSuccessStatusCode();

                    var result = await response.Content.ReadAsStringAsync();
                    var blsResult = JsonConvert.DeserializeObject<BlsApiReturn>(result);

                    if (blsResult != null && blsResult.Results != null)
                    {
                        foreach (Series returnSeries in blsResult.Results.series)
                        {
                            //var sortedData =returnSeries.data.OrderBy(d => d.value).ThenBy(m => m.period);
                            //returnSeries.data = sortedData.ToList();
                            completeSeries.Add(returnSeries);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                return completeSeries;
                    
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw e;
            }
        }

        private JObject ParseToBlsPostObject(List<string> seriesIDs, int startYear, int endYear)
        {
            var returnJObject = new JObject();
            var JseriesId = new JArray();
            foreach(string seriesID in seriesIDs)
            {
                JseriesId.Add(seriesID);
            }
            returnJObject.Add("seriesid", JseriesId);
            if (startYear == 0 || endYear == 0)
                return returnJObject;
            returnJObject.Add("startyear", startYear.ToString());
            returnJObject.Add("endyear", endYear.ToString());
            return returnJObject;
        }

        private string ParseToBlsPostString(List<string> seriesIDs, int startYear, int endYear)
        {
            StringBuilder jsonStringBuilder = new StringBuilder();
            jsonStringBuilder.Append("{\"seriesid\":[");
            
            for(int i = 0; i < seriesIDs.Count; i++)
            {
                if(i == seriesIDs.Count - 1)
                    jsonStringBuilder.Append("\"" + seriesIDs[i] + "\"]");
                else
                    jsonStringBuilder.Append("\"" + seriesIDs[i] + "\",");
            }

            if (startYear == 0 || endYear == 0)
            {
                jsonStringBuilder.Append("}");
                return jsonStringBuilder.ToString();
            }
            jsonStringBuilder.Append(", ");
            jsonStringBuilder.Append("\"startyear\":\"" + startYear.ToString() + "\",");
            jsonStringBuilder.Append("\"endyear\":\"" + endYear.ToString() + "\"}");
            return jsonStringBuilder.ToString();
        }

    }
}
