using BLS_API_Portable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.LocalUnemployment
{
    public class LocalCsvOutput
    {
        public LocalCsvOutput(List<RegionSeries> listOfRegions) { }

        public static string OutputByStateMessage(List<RegionSeries> listOfRegions)
        {
            int regionCount = listOfRegions.Count;
            return "This will output " + regionCount.ToString() + " files, one for each region.";
        }
        
        public static List<List<string>> GetRowHeaders(BlsSeries bs, List<List<string>> outputFile)
        {
            if(outputFile.Count < 2)
            {
                foreach(BLSDataPoint data in bs.data)
                {
                    List<string> row = new List<string>();
                    row.Add(data.period.Substring(1,2) + "/" + data.year);
                    outputFile.Add(row);
                }
            }
            
            return outputFile;
        }

        public static Dictionary<string, List<List<string>>> OutputByState(List<RegionSeries> listOfRegions)
        {
            // Each dictionary entry consists of a file name and a list 
            //   of string that indicate the rows.

            Dictionary<string, List<List<string>>> finalOutput = new Dictionary<string, List<List<string>>>();
            int lineCount = 0;
            int columnCount = 1;
            
            foreach (RegionSeries rs in listOfRegions)
            {
                List<List<string>> stateFile = new List<List<string>>();
                List<string> header = new List<string>();

                stateFile.Add(new List<string>());
                stateFile[0].Add("Date");

                #region Add Labor Force Data
                if (rs.LaborForce != null)
                {
                    stateFile[0].Add("Labor Force");
                    stateFile = GetRowHeaders(rs.LaborForce, stateFile);
                    for(int i = 0; i < rs.LaborForce.data.Count; i++)
                    {
                        BLSDataPoint bdp = rs.LaborForce.data[i];
                        if(i < stateFile.Count - 2)
                        {
                            string dataDate = bdp.period.Substring(1,2) + "/" + bdp.year;
                            if(stateFile[i+1][0] == dataDate)
                                stateFile[i+1].Add(bdp.value);
                        }
                    }
                }
                #endregion

                #region Add Employment Data
                if (rs.Employment != null)
                {   
                    stateFile[0].Add("Employed");
                    stateFile = GetRowHeaders(rs.Employment, stateFile);
                    for(int i = 0; i < rs.Employment.data.Count; i++)
                    {
                        BLSDataPoint bdp = rs.Employment.data[i];
                        if(i < stateFile.Count - 2)
                        {
                            string dataDate = bdp.period.Substring(1,2) + "/" + bdp.year;
                            if(stateFile[i+1][0] == dataDate)
                                stateFile[i+1].Add(bdp.value);
                        }
                    }
                }
                #endregion

                #region Add Unemployment Data
                if (rs.Unemployment != null)
                {
                    stateFile[0].Add("Unemployed");
                    stateFile = GetRowHeaders(rs.Unemployment, stateFile);
                    for(int i = 0; i < rs.Unemployment.data.Count; i++)
                    {
                        BLSDataPoint bdp = rs.Unemployment.data[i];
                        if(i < stateFile.Count - 2)
                        {
                            string dataDate = bdp.period.Substring(1,2) + "/" + bdp.year;
                            if(stateFile[i+1][0] == dataDate)
                                stateFile[i+1].Add(bdp.value);
                        }
                    }
                }
                #endregion

                #region Add Unemployment Rate Data
                if (rs.UnemploymentRate != null)
                {
                    stateFile[0].Add("Unemployment Rate");
                    stateFile = GetRowHeaders(rs.UnemploymentRate, stateFile);
                    for(int i = 0; i < rs.UnemploymentRate.data.Count; i++)
                    {
                        BLSDataPoint bdp = rs.UnemploymentRate.data[i];
                        if(i < stateFile.Count - 2)
                        {
                            string dataDate = bdp.period.Substring(1,2) + "/" + bdp.year;
                            if(stateFile[i+1][0] == dataDate)
                                stateFile[i+1].Add(bdp.value);
                        }
                    }

                }
                #endregion
                
                finalOutput[rs.RegionName] = stateFile;
            }

            return finalOutput;
        }

        public static string OutputByMeasureMessage(List<RegionSeries> listOfRegions)
        {
            int regionCount = 0;
            if (listOfRegions.Count > 0)
            {
                if (listOfRegions[0].Employment != null && listOfRegions[0].Employment.data.Count > 0)
                    regionCount++;

                if (listOfRegions[0].Unemployment != null && listOfRegions[0].Unemployment.data.Count > 0)
                    regionCount++;

                if (listOfRegions[0].UnemploymentRate != null && listOfRegions[0].UnemploymentRate.data.Count > 0)
                    regionCount++;

                if (listOfRegions[0].LaborForce != null && listOfRegions[0].LaborForce.data.Count > 0)
                    regionCount++;

            }
            return "This will output " + regionCount.ToString() + " files, one for each employment measure.";
        }

        public static Dictionary<string, List<List<string>>> OutputByMeasure(List<RegionSeries> listOfRegions)
        {
            Dictionary<string, List<List<string>>> finalOutput = new Dictionary<string, List<List<string>>>();

            // 1) find the measures, create a list of those measures
            // 2) go through each state and seperate out the measure data
            // 3) go through the measure list and build the files
            List<List<BlsSeries>> measures = new List<List<BlsSeries>>();

            List<BlsSeries> Employment = new List<BlsSeries>();
            List<BlsSeries> Unemployment = new List<BlsSeries>();
            List<BlsSeries> UnemploymentRate = new List<BlsSeries>();
            List<BlsSeries> LaborForce = new List<BlsSeries>();

            List<string> header = new List<string>();
            header.Add("Date");

            #region Seperate out the series by measure type

            foreach (RegionSeries rs in listOfRegions)
            {
                header.Add(rs.RegionName);
                if (rs.Employment != null)
                    Employment.Add(rs.Employment);
                if (rs.Unemployment != null)
                    Unemployment.Add(rs.Unemployment);
                if (rs.UnemploymentRate != null)
                    UnemploymentRate.Add(rs.UnemploymentRate);
                if (rs.LaborForce != null)
                    LaborForce.Add(rs.LaborForce);
            }

            #endregion

            #region Unmployment list population
            if (Unemployment.Count != 0)
            {
                List<List<string>> unemploymentStrings = new List<List<string>>();
                unemploymentStrings.Add(header);
                bool isRowsSet = false;

                #region Set the Rows
                foreach (var blsData in Unemployment) 
                {
                    if (!isRowsSet)
                    {
                        unemploymentStrings = GetRowHeaders(blsData, unemploymentStrings);
                        isRowsSet = true;
                    }

                    for (int i = 0; i < blsData.data.Count; i++)
                    {
                        BLSDataPoint bdp = blsData.data[i];
                        if (i < unemploymentStrings.Count - 1)
                        {
                            string dataDate = bdp.period.Substring(1, 2) + "/" + bdp.year;
                            if (unemploymentStrings[i + 1][0] == dataDate)
                                unemploymentStrings[i + 1].Add(bdp.value);
                        }
                    }
                }
                #endregion

                finalOutput["Unemployment"] = unemploymentStrings;
            }
            #endregion

            #region Employment list population
            if (Employment.Count != 0)
            {
                List<List<string>> employmentStrings = new List<List<string>>();
                employmentStrings.Add(header);
                bool isRowsSet = false;
                foreach (var blsData in Employment)
                {
                    if (!isRowsSet)
                    {
                        employmentStrings = GetRowHeaders(blsData, employmentStrings);
                        isRowsSet = true;
                    }

                    for (int i = 0; i < blsData.data.Count; i++)
                    {
                        BLSDataPoint bdp = blsData.data[i];
                        string dataDate = bdp.period.Substring(1, 2) + "/" + bdp.year;
                        for(int k = 1; k < employmentStrings.Count; k++)
                        {
                            if (employmentStrings[k][0] == dataDate)
                                employmentStrings[k].Add(bdp.value);
                        }
                    }
                }
                // Add something to get rid of the M13 data
                finalOutput["Employment"] = employmentStrings;
            }
            #endregion

            #region Labor Force list population
            if (LaborForce.Count != 0)
            {
                List<List<string>> lfStrings = new List<List<string>>();
                lfStrings.Add(header);

                bool isRowsSet = false;
                foreach (var blsData in LaborForce)
                {
                    if (!isRowsSet)
                    {
                        lfStrings = GetRowHeaders(blsData, lfStrings);
                        isRowsSet = true;
                    }

                    for (int i = 0; i < blsData.data.Count; i++)
                    {
                        BLSDataPoint bdp = blsData.data[i];
                        if (i < lfStrings.Count - 1)
                        {
                            string dataDate = bdp.period.Substring(1, 2) + "/" + bdp.year;
                            if (lfStrings[i + 1][0] == dataDate)
                                lfStrings[i + 1].Add(bdp.value);
                        }
                    }
                }
                // Add something to get rid of the M13 data
                finalOutput["Labor Force"] = lfStrings;
            }
            #endregion

            #region Unemployment Rate list population
            if (UnemploymentRate.Count != 0)
            {
                List<List<string>> urStrings = new List<List<string>>();
                urStrings.Add(header);

                bool isRowsSet = false;
                foreach (var blsData in UnemploymentRate)
                {
                    if (!isRowsSet)
                    {
                        urStrings = GetRowHeaders(blsData, urStrings);
                        isRowsSet = true;
                    }

                    for (int i = 0; i < blsData.data.Count; i++)
                    {
                        BLSDataPoint bdp = blsData.data[i];

                        if (i < urStrings.Count - 1)
                        {
                            string dataDate = bdp.period.Substring(1, 2) + "/" + bdp.year;
                            if (urStrings[i + 1][0] == dataDate)
                                urStrings[i + 1].Add(bdp.value);
                        }
                    }
                }
                // Add something to get rid of the M13 data
                finalOutput["Unemplpoyment Rate"] = urStrings;
            }
            #endregion

            return finalOutput;
        }
    
    }
}
