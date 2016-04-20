using BLS_API_Portable.Common;
using BLS_API_Portable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.LocalUnemployment
{
    public class RegionSeries 
    {
        public RegionSeries()
        {

        }

        //public string RegionName { get; set;}
        public string RegionName { get; set; }
        public BlsSeries Employment { get; set; }
        public BlsSeries Unemployment { get; set; }
        public BlsSeries UnemploymentRate { get; set; }
        public BlsSeries LaborForce { get; set; }

        
    }
}
