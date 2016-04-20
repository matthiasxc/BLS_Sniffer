using BLS_API_Portable.CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable
{
    public enum EmploymentMeasure
    {
        UnemploymentRate, 
        Unemployment,
        Employment, 
        LaborForce
    }
    public static class EmploymentMeasures
    {
        private static Dictionary<EmploymentMeasure, BlsField> measures { get; set; }
        public static Dictionary<EmploymentMeasure, BlsField> Dictionary
        {
            get
            {
                if (measures == null)
                {
                    measures = new Dictionary<EmploymentMeasure, BlsField>();
                    measures.Add(EmploymentMeasure.UnemploymentRate, new BlsField(){Code="03", Description = "Unemployment Rate"});
                    measures.Add(EmploymentMeasure.Unemployment, new BlsField(){Code="04", Description = "Unemployed"});
                    measures.Add(EmploymentMeasure.Employment, new BlsField(){Code="05", Description = "Employed"});
                    measures.Add(EmploymentMeasure.LaborForce, new BlsField() { Code = "06", Description = "Labor Force" });
                }

                return measures;
            }
        }
    }
}
