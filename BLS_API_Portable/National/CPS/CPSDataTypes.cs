using BLS_API_Portable.CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.National.CPS
{
    public static class CPSDataTypes
    {
        // Out of LNS12300000
        // Base: LN - CPS data
        // ?? : S - Seasonally adjusted
        // Type : 123 - CPS Type
        //
        // Men: LNS12300001
        // White: LNS11300003
        // Hispanic: LNS12300009
        // 16-17 yrs: LNS12300086

        private static Dictionary<CPSType, BlsField> cpsDict { get; set; }
        public static Dictionary<CPSType, BlsField> Dictionary
        {
            get
            {
                if (cpsDict == null)
                {
                    cpsDict = new Dictionary<CPSType, BlsField>();
                    cpsDict.Add(CPSType.Population, new BlsField() { Code = "LNS10000000", Description = "Population Level" });
                    cpsDict.Add(CPSType.LaborForce, new BlsField() { Code = "LNS11000000", Description = "Civilian Labor Force Level" });
                    cpsDict.Add(CPSType.LaborForceParticipation, new BlsField() { Code = "LNS11300000", Description = "Labor Force Participation Rate" });
                    cpsDict.Add(CPSType.Employed, new BlsField() { Code = "LNS12000000", Description = "Employment Level" });
                    cpsDict.Add(CPSType.EmployedPopulationRatio, new BlsField() { Code = "LNS12300000", Description = "Employment-Population Ratio" });
                    cpsDict.Add(CPSType.EmployedFullTime, new BlsField() { Code = "LNS12500000", Description = "Employed, Usually Work Full Time" });
                    cpsDict.Add(CPSType.EmployedPartTime, new BlsField() { Code = "LNS12600000", Description = "Employed, Usually Work Part Time" });
                    cpsDict.Add(CPSType.Unemployed, new BlsField() { Code = "LNS13000000", Description = "Unemployment Level" });
                }
                return cpsDict;
            }
        }

        public static List<CPSType> AllCPSTypes()
        {
            List<CPSType> allCPSTypes = new List<CPSType>();
            foreach (CPSType type in (CPSType[])Enum.GetValues(typeof(CPSType)))
                allCPSTypes.Add(type);
            return allCPSTypes;
        }
    }

    public enum CPSType
    {
        Population, // LNS10000000
        LaborForce, // LNS11000000
        LaborForceParticipation, // LNS11300000
        Employed, // LNS12000000
        EmployedPopulationRatio, // LNS12300000
        EmployedFullTime, // LNS12500000
        EmployedPartTime, // LNS12600000
        Unemployed // LNS13000000
    }
}
