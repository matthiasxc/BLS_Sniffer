using BLS_API_Portable.Common;
using BLS_API_Portable.CommonTypes;
using BLS_API_Portable.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.LocalUnemployment
{
    public class LocalUnemploymentParser 
    {
        // The description of the Local Employment series construction is
        //   located here: http://www.bls.gov/help/hlpforma.htm#LA

        protected BLSSeriesTypes SeriesType = BLSSeriesTypes.LA;

        public string GetSeriesID() { return ""; }
        public string GetStateSeriesID(State state, EmploymentMeasure measure, Adjustment adjust)
        {
            // The Virgin Islands is missing from this data set 
            if(state == State.VirginIslands)
            {
                Exception e = new Exception("This data set has no data for the Virgin Islands. If you used the AllStatesAndTerritories method, consider using AllStatesAndTerritoriesLA instead.");
                throw e;
            }

            // Creation Process
            // Step 1) Determine the prefix
            // Step 2) set the seasonal setting
            // Step 3) accept a string (drawn from the StateCodes type)
            // Step 4) accept a measure code
            string testString = "";
            StringBuilder seriesString = new StringBuilder();
            seriesString.Append(this.SeriesType.ToString());
            seriesString.Append(Adjustments.Dictionary[adjust].Code);

            // We already know we're looking at a state, so just add that prefix
            seriesString.Append("ST");
            var allStates = States.Dictionary;
            seriesString.Append(allStates[state].Code);
            seriesString.Append("00000000000");
            seriesString.Append(EmploymentMeasures.Dictionary[measure].Code);


            //Test string version
            testString = this.SeriesType.ToString() + Adjustments.Dictionary[adjust] + allStates[state] + "00000000000" + EmploymentMeasures.Dictionary[measure];
            string resultString = seriesString.ToString();
            return seriesString.ToString();
        }

        public SeriesParams ParseSeriesID(string idInput)
        {
            SeriesParams returnParams = new SeriesParams();
            string prefix = idInput.Substring(0, 2);
            if(prefix != this.SeriesType.ToString())
            {
                Exception e = new Exception("You are using the wrong parser. The prefix of the series ID must be 'LA' for this parser to work");
                throw e;
            }

            string seasonalAdjustment = "";
            foreach (KeyValuePair<Adjustment, BlsField> kvp in Adjustments.Dictionary)
            {
                if (idInput.Substring(2, 1) == kvp.Value.Code)
                {
                    returnParams.Adjust = kvp.Key;
                    seasonalAdjustment = kvp.Value.Description;
                }
            }

            // Return to this when I have the area types figured out
            //string areaTypeCode = idInput.Substring(3, 2);
            //foreach (KeyValuePair<Adjustment, string> kvp in Adjustments.Dictionary)
            //{
            //    if (idInput.Substring(2, 1) == kvp.Value)
            //        seasonalAdjustment = kvp.Key.ToString();
            //}

            string region = "";
            if(idInput.Substring(3, 2) == "ST")
            {
                foreach (KeyValuePair<State, BlsField> kvp in States.Dictionary)
                {
                    if (kvp.Value.Code == idInput.Substring(5, 2)) 
                    {
                        returnParams.Region = kvp.Key;
                        region = kvp.Value.Description;
                    }
                }
            }

            string dataType = "";
            foreach (KeyValuePair<EmploymentMeasure, BlsField> kvp in EmploymentMeasures.Dictionary)
            {
                if (idInput.Substring(18, 2) == kvp.Value.Code)
                {
                    returnParams.Measure = kvp.Key;
                    dataType = kvp.Value.Description;
                }
            }

            returnParams.Description = region + " " + dataType + " (" + seasonalAdjustment + ")";
            return returnParams;
        }
    }

    public enum LAAreaType 
    {
        Statewide,	           // A - ST
        MetropolitanArea,      // B - MT
        MetropolitanDivisions, // C	- DV
        MicropolitanArea,      // D - MC
        CombinedAreas,	       // E - CA
        Counties,              // F - CN
        CitiesOver25K,	       // G - CT
        CitiesUnder25K,        // H - CS
        PartsOfCities,         // I - PT
        SmallLaborMarket,      // J - SA
        InterstateAreas,	   // K -ID, IM
        BalanceOfStateAreas,   // L - BS
        CensusRegions,         // M - RD
        CensusDivisions        // N - RD
    }

    public enum LAMeasureCode 
    {
        UnemploymentRate,  // 03
        Unemployment,      // 04
        Employment,        // 05
        LaborForce        // 06
    }



//A	ST0100000000000	Alabama	0	T	1	
//A	ST0200000000000	Alaska	0	T	143	
//A	ST0400000000000	Arizona	0	T	187	
//A	ST0500000000000	Arkansas	0	T	250	
//A	ST0600000000000	California	0	T	374	
//A	ST0800000000000	Colorado	0	T	748	
//A	ST0900000000000	Connecticut	0	T	869	
//A	ST1000000000000	Delaware	0	T	1062	
//A	ST1100000000000	District of Columbia	0	T	1073	
//A	ST1200000000000	Florida	0	T	1080	
//A	ST1300000000000	Georgia	0	T	1278	
//A	ST1500000000000	Hawaii	0	T	1521	
//A	ST1600000000000	Idaho	0	T	1531	
//A	ST1700000000000	Illinois	0	T	1607	
//A	ST1800000000000	Indiana	0	T	1881	
//A	ST1900000000000	Iowa	0	T	2059	
//A	ST2000000000000	Kansas	0	T	2214	
//A	ST2100000000000	Kentucky	0	T	2360	
//A	ST2200000000000	Louisiana	0	T	2530	
//A	ST2300000000000	Maine	0	T	2643	
//A	ST2400000000000	Maryland	0	T	3215	
//A	ST2500000000000	Massachusetts	0	T	3264	
//A	ST2600000000000	Michigan	0	T	3663	
//A	ST2700000000000	Minnesota	0	T	3881	
//A	ST2800000000000	Mississippi	0	T	4042	
//A	ST2900000000000	Missouri	0	T	4175	
//A	ST3000000000000	Montana	0	T	4361	
//A	ST3100000000000	Nebraska	0	T	4433	
//A	ST3200000000000	Nevada	0	T	4550	
//A	ST3300000000000	New Hampshire	0	T	4584	
//A	ST3400000000000	New Jersey	0	T	4870	
//A	ST3500000000000	New Mexico	0	T	5004	
//A	ST3600000000000	New York	0	T	5069	
//A	ST3700000000000	North Carolina	0	T	5269	
//A	ST3800000000000	North Dakota	0	T	5472	
//A	ST3900000000000	Ohio	0	T	5543	
//A	ST4000000000000	Oklahoma	0	T	5770	
//A	ST4100000000000	Oregon	0	T	5897	
//A	ST4200000000000	Pennsylvania	0	T	5988	
//A	ST4400000000000	Rhode Island	0	T	6169	
//A	ST4500000000000	South Carolina	0	T	6218	
//A	ST4600000000000	South Dakota	0	T	6318	
//A	ST4700000000000	Tennessee	0	T	6403	
//A	ST4800000000000	Texas	0	T	6577	
//A	ST4900000000000	Utah	0	T	7094	
//A	ST5000000000000	Vermont	0	T	7166	
//A	ST5100000000000	Virginia	0	T	7452	
//A	ST5300000000000	Washington	0	T	7652	
//A	ST5400000000000	West Virginia	0	T	7761	
//A	ST5500000000000	Wisconsin	0	T	7849	
//A	ST5600000000000	Wyoming	0	T	7998	
//A	ST7200000000000	Puerto Rico	0	T	8036	


    
}
