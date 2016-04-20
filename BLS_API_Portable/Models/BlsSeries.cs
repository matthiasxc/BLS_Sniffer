using BLS_API_Portable.LocalUnemployment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.Models
{
    public class BlsSeries : Series
    {
        public BlsSeries() { }
        public BlsSeries(Series s) 
        {
            this.data = s.data;
            this.seriesID = s.seriesID;
        }
        
        public String Description { get; set; }
        public SeriesParams Params { get; set; }
        public override string ToString()
        {
            if (Description != null && Description == "")
                return Description;
            else
                return base.ToString();
        }
    }
}
