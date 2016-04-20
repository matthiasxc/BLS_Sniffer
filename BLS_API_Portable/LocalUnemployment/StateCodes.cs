
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.LocalUnemployment
{
    public static class StateCodes
    {
        public static string StatePrefix = "ST";
        public static string Alabama = "ST0100000000000";	
        public static string Alaska = "ST0200000000000";		
        public static string Arizona = "ST0400000000000";		
        public static string Arkansas = "ST0500000000000";		
        public static string California= "ST0600000000000";		
        public static string Colorado = "ST0800000000000";		
        public static string Connecticut = "ST0900000000000";	
        public static string Delaware = "ST1000000000000";		
        public static string DC = "ST1100000000000";	
        public static string Florida = "ST1200000000000";		
        public static string Georgia = "ST1300000000000";		
        public static string Hawaii = "ST1500000000000";		
        public static string Idaho = "ST1600000000000";		
        public static string Illinois = "ST1700000000000";		
        public static string Indiana = "ST1800000000000";		
        public static string Iowa = "ST1900000000000";
        public static string Kansas = "ST2000000000000";		
        public static string Kentucky = "ST2100000000000";		
        public static string Louisiana = "ST2200000000000";		
        public static string Maine = "ST2300000000000";		
        public static string Maryland = "ST2400000000000";		
        public static string Massachusetts = "ST2500000000000";	
        public static string Michigan = "ST2600000000000";		
        public static string Minnesota = "ST2700000000000";		
        public static string Mississippi = "ST2800000000000";	
        public static string Missouri = "ST2900000000000";		
        public static string Montana = "ST3000000000000";		
        public static string Nebraska = "ST3100000000000";		
        public static string Nevada = "ST3200000000000";		
        public static string NewHampshire = "ST3300000000000";	
        public static string NewJersey = "ST3400000000000";		
        public static string NewMexico = "ST3500000000000";		
        public static string NewYork = "ST3600000000000";		
        public static string NorthCarolina = "ST3700000000000";	
        public static string NorthDakota = "ST3800000000000";	
        public static string Ohio = "ST3900000000000";	
        public static string Oklahoma = "ST4000000000000";		
        public static string Oregon	= "ST4100000000000";		
        public static string Pennsylvania = "ST4200000000000";	
        public static string RhodeIsland = "ST4400000000000";	
        public static string SouthCarolina = "ST4500000000000";	
        public static string SouthDakota = "ST4600000000000";	
        public static string Tennessee = "ST4700000000000";		
        public static string Texas = "ST4800000000000";
        public static string Utah = "ST4900000000000";
        public static string Vermont= "ST5000000000000";		
        public static string Virginia = "ST5100000000000";		
        public static string Washington = "ST5300000000000";	
        public static string WestVirginia = "ST5400000000000";	
        public static string Wisconsin = "ST5500000000000";		
        public static string Wyoming = "ST5600000000000";		
        public static string PuertoRico	= "ST7200000000000";

        public static List<string> AllStatesAndTerritories()
        {
            List<string> statesList = StateCodes.AllStates();
    
            statesList.Add(StateCodes.PuertoRico);
           
            return statesList;
        }

        public static List<string> AllStates()
        {
            List<string> statesList = new List<string>();
            statesList.Add(StateCodes.Alabama);
            statesList.Add(StateCodes.Alaska);
            statesList.Add(StateCodes.Arizona);
            statesList.Add(StateCodes.Arkansas);
            statesList.Add(StateCodes.California);
            statesList.Add(StateCodes.Colorado);
            statesList.Add(StateCodes.Connecticut);
            statesList.Add(StateCodes.Delaware);
            statesList.Add(StateCodes.DC);
            statesList.Add(StateCodes.Florida);
            statesList.Add(StateCodes.Georgia);
            statesList.Add(StateCodes.Hawaii);
            statesList.Add(StateCodes.Idaho);
            statesList.Add(StateCodes.Illinois);
            statesList.Add(StateCodes.Indiana);
            statesList.Add(StateCodes.Iowa);
            statesList.Add(StateCodes.Kansas);
            statesList.Add(StateCodes.Kentucky);
            statesList.Add(StateCodes.Louisiana);
            statesList.Add(StateCodes.Maine);
            statesList.Add(StateCodes.Maryland);
            statesList.Add(StateCodes.Massachusetts);
            statesList.Add(StateCodes.Michigan);
            statesList.Add(StateCodes.Minnesota);
            statesList.Add(StateCodes.Mississippi);
            statesList.Add(StateCodes.Missouri);
            statesList.Add(StateCodes.Montana);
            statesList.Add(StateCodes.Nebraska);
            statesList.Add(StateCodes.Nevada);
            statesList.Add(StateCodes.NewHampshire);
            statesList.Add(StateCodes.NewJersey);
            statesList.Add(StateCodes.NewMexico);
            statesList.Add(StateCodes.NewYork);
            statesList.Add(StateCodes.NorthCarolina);
            statesList.Add(StateCodes.NorthDakota);
            statesList.Add(StateCodes.Ohio);
            statesList.Add(StateCodes.Oklahoma);
            statesList.Add(StateCodes.Oregon);
            statesList.Add(StateCodes.Pennsylvania);
            statesList.Add(StateCodes.RhodeIsland);
            statesList.Add(StateCodes.SouthCarolina);
            statesList.Add(StateCodes.SouthDakota);
            statesList.Add(StateCodes.Tennessee);
            statesList.Add(StateCodes.Texas);
            statesList.Add(StateCodes.Utah);
            statesList.Add(StateCodes.Vermont);
            statesList.Add(StateCodes.Virginia);
            statesList.Add(StateCodes.Washington);
            statesList.Add(StateCodes.WestVirginia);
            statesList.Add(StateCodes.Wisconsin);
            statesList.Add(StateCodes.Wyoming);

            return statesList;
        }

    }
}
