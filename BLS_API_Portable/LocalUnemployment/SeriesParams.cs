using BLS_API_Portable.Common;
using BLS_API_Portable.CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.LocalUnemployment
{
    public class SeriesParams
    {
        public SeriesParams()
        {

        }

        public State Region { get; set; }
        public Adjustment Adjust { get; set; }
        public EmploymentMeasure Measure { get; set; }

        public string Description { get; set; }

    }
}
