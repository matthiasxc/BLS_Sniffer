using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.LocalUnemployment
{
    public class LAMeasureCodes
    {
        public static string UnemploymentRate = "03";
        public static string Unemployed = "04";
        public static string Employed = "05";
        public static string LaborForce = "06";

        public static List<string> All()
        {
            List<string> allTypes = new List<string>();
            allTypes.Add(LAMeasureCodes.UnemploymentRate);
            allTypes.Add(LAMeasureCodes.Unemployed);
            allTypes.Add(LAMeasureCodes.Employed);
            allTypes.Add(LAMeasureCodes.LaborForce);
            return allTypes;
        }
    }
}
