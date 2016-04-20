
using BLS_API_Portable.CommonTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.Common
{
    public static class States
    {
        private static Dictionary<State, BlsField> stateDict { get; set; }
        public static Dictionary<State, BlsField> Dictionary
        {
            get
            {
                if (stateDict == null)
                {
                    stateDict = new Dictionary<State, BlsField>();
                    stateDict.Add(State.Alabama, new BlsField() { Code = "01", Description = "Alabama" });
                    stateDict.Add(State.Alaska, new BlsField() { Code = "02", Description = "Alaska" });
                    stateDict.Add(State.Arizona, new BlsField() { Code = "04", Description = "Arizona" });
                    stateDict.Add(State.Arkansas, new BlsField() { Code = "05", Description = "Arkansas" });
                    stateDict.Add(State.California, new BlsField() { Code = "06", Description = "California" });
                    stateDict.Add(State.Colorado, new BlsField() { Code = "08", Description = "Colorado" });
                    stateDict.Add(State.Connecticut, new BlsField() { Code = "09", Description = "Connecticut" });
                    stateDict.Add(State.Delaware, new BlsField() { Code = "10", Description = "Delaware" });
                    stateDict.Add(State.DistrictOfColumbia, new BlsField() { Code = "11", Description = "District of Columbia" });
                    stateDict.Add(State.Florida, new BlsField() { Code = "12", Description = "Florida" });
                    stateDict.Add(State.Georgia, new BlsField() { Code = "13", Description = "Georgia" });
                    stateDict.Add(State.Hawaii, new BlsField() { Code = "15", Description = "Hawaii" });
                    stateDict.Add(State.Idaho, new BlsField() { Code = "16", Description = "Idaho" });
                    stateDict.Add(State.Illinois, new BlsField() { Code = "17", Description = "Illinois" });
                    stateDict.Add(State.Indiana, new BlsField() { Code = "18", Description = "Indiana" });
                    stateDict.Add(State.Iowa, new BlsField() { Code = "19", Description = "Iowa" });
                    stateDict.Add(State.Kansas, new BlsField() { Code = "20", Description = "Kansas" });
                    stateDict.Add(State.Kentucky, new BlsField() { Code = "21", Description = "Kentucky" });
                    stateDict.Add(State.Louisiana, new BlsField() { Code = "22", Description = "Louisiana" });
                    stateDict.Add(State.Maine, new BlsField() { Code = "23", Description = "Maine" });
                    stateDict.Add(State.Maryland, new BlsField() { Code = "24", Description = "Maryland" });
                    stateDict.Add(State.Massachusetts, new BlsField() { Code = "25", Description = "Massachusetts" });
                    stateDict.Add(State.Michigan, new BlsField() { Code = "26", Description = "Michigan" });
                    stateDict.Add(State.Minnesota, new BlsField() { Code = "27", Description = "Minnesota" });
                    stateDict.Add(State.Mississippi, new BlsField() { Code = "28", Description = "Mississippi" });
                    stateDict.Add(State.Missouri, new BlsField() { Code = "29", Description = "Missouri" });
                    stateDict.Add(State.Montana, new BlsField() { Code = "30", Description = "Montana" });
                    stateDict.Add(State.Nebraska, new BlsField() { Code = "31", Description = "Nebraska" });
                    stateDict.Add(State.Nevada, new BlsField() { Code = "32", Description = "Nevada" });
                    stateDict.Add(State.NewHampshire, new BlsField() { Code = "33", Description = "New Hampshire" });
                    stateDict.Add(State.NewJersey, new BlsField() { Code = "34", Description = "New Jersey" });
                    stateDict.Add(State.NewMexico, new BlsField() { Code = "35", Description = "New Mexico" });
                    stateDict.Add(State.NewYork, new BlsField() { Code = "36", Description = "New York" });
                    stateDict.Add(State.NorthCarolina, new BlsField() { Code = "37", Description = "North Carolina" });
                    stateDict.Add(State.NorthDakota, new BlsField() { Code = "38", Description = "North Dakota" });
                    stateDict.Add(State.Ohio, new BlsField() { Code = "39", Description = "Ohio" });
                    stateDict.Add(State.Oklahoma, new BlsField() { Code = "40", Description = "Oklahoma" });
                    stateDict.Add(State.Oregon, new BlsField() { Code = "41", Description = "Oregon" });
                    stateDict.Add(State.Pennsylvania, new BlsField() { Code = "42", Description = "Pennsylvania" });
                    stateDict.Add(State.RhodeIsland, new BlsField() { Code = "44", Description = "Rhode Island" });
                    stateDict.Add(State.SouthCarolina, new BlsField() { Code = "45", Description = "South Carolina" });
                    stateDict.Add(State.SouthDakota, new BlsField() { Code = "46", Description = "South Dakota" });
                    stateDict.Add(State.Tennessee, new BlsField() { Code = "47", Description = "Tennessee" });
                    stateDict.Add(State.Texas, new BlsField() { Code = "48", Description = "Texas" });
                    stateDict.Add(State.Utah, new BlsField() { Code = "49", Description = "Utah" });
                    stateDict.Add(State.Vermont, new BlsField() { Code = "50", Description = "Vermont" });
                    stateDict.Add(State.Virginia, new BlsField() { Code = "51", Description = "Virginia" });
                    stateDict.Add(State.Washington, new BlsField() { Code = "53", Description = "Washington" });
                    stateDict.Add(State.WestVirginia, new BlsField() { Code = "54", Description = "West Virginia" });
                    stateDict.Add(State.Wisconsin, new BlsField() { Code = "55", Description = "Wisconsin" });
                    stateDict.Add(State.Wyoming, new BlsField() { Code = "56", Description = "Wyoming" });
                    stateDict.Add(State.PuertoRico, new BlsField() { Code = "72", Description = "Puerto Rico" });
                    stateDict.Add(State.VirginIslands, new BlsField() { Code = "78", Description = "Virgin Islands" });
                }
                return stateDict;
            }
        }

        public static List<State> AllStates()
        {
            List<State> allStates = new List<State>();
            foreach (State state in (State[])Enum.GetValues(typeof(State)))
            {
                if (state != State.PuertoRico && state != State.VirginIslands)
                    allStates.Add(state);
            }
            return allStates;
        }

        public static List<State> AllStatesAndTerritories()
        {
            List<State> allStates = new List<State>();
            foreach (State state in (State[])Enum.GetValues(typeof(State)))
            {
                    allStates.Add(state);
            }
            return allStates;
        }

        public static List<State> AllStatesAndTerritoriesLA()
        {
            List<State> allStates = new List<State>();
            foreach (State state in (State[])Enum.GetValues(typeof(State)))
            {
                if(state != State.VirginIslands)
                    allStates.Add(state);
            }
            return allStates;
        }
    }

    public enum State
    {
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        DistrictOfColumbia,	
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        NewHampshire,
        NewJersey,
        NewMexico,
        NewYork,
        NorthCarolina,
        NorthDakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        RhodeIsland,
        SouthCarolina,
        SouthDakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        WestVirginia,
        Wisconsin,
        Wyoming,
        PuertoRico,
        VirginIslands 
    }
}
