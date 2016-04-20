using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable
{
    public class Seasonal
    {
        public static string SeasonallyAdjusted = "S";
        public static string Unadjusted = "U";
        private static Dictionary<string, string> all;
    
        public static Dictionary<string, string> All
        {
            get
            {
                if (all == null)
                {
                    all = new Dictionary<string, string>();
                    all.Add("SeasonallyAdjusted", "S");
                    all.Add("Unadjusted", "U");
                }
                return all;
            }
        }
    }
}
