using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.CommonTypes
{
    public enum Adjustment
    {
        Seasonal,
        Unadjusted
    }

    public static class Adjustments
    {
        private static Dictionary<Adjustment, BlsField> adjustDict { get; set; }
        public static Dictionary<Adjustment, BlsField> Dictionary
        {
            get
            {
                if (adjustDict == null)
                {
                    adjustDict = new Dictionary<Adjustment, BlsField>();
                    adjustDict.Add(Adjustment.Seasonal, new BlsField() { Code = "S", Description = "Seasonally Adjusted" });
                    adjustDict.Add(Adjustment.Unadjusted, new BlsField(){Code="U", Description="Unadjusted"});
                }
                return adjustDict;
            }
        }


    }
}
