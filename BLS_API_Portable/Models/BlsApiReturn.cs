using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable.Models
{
    // This BLS entity is described here:
    //   http://www.bls.gov/developers/api_signature.htm

    public class Footnote
    {
        public string code { get; set; }
        public string text { get; set; }
    }

    public class BLSDataPoint
    {
        public string year { get; set; }
        public string period { get; set; }
        public string periodName { get; set; }
        public string value { get; set; }
        public List<Footnote> footnotes { get; set; }
    }

    public class Series
    {
        public string seriesID { get; set; }
        public List<BLSDataPoint> data { get; set; }
    }

    public class BlsResults
    {
        public List<Series> series { get; set; }
    }

    public class BlsApiReturn
    {
        public string status { get; set; }
        public int responseTime { get; set; }
        public List<object> message { get; set; }
        public BlsResults Results { get; set; }
    }

}
