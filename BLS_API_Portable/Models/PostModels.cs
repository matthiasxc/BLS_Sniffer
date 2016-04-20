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
    public class MultipleSeries
    {
        public MultipleSeries(){}

        #region SeriesList Property (List<string>)
        private List<string> _seriesList;
        [JsonProperty(PropertyName = "seriesid")]
        public List<string> SeriesList
        {
            get { return _seriesList; }
            set { _seriesList = value; }
        }
        #endregion

        #region StartYear Property (string)
        private string _startYear;
        [JsonProperty(PropertyName = "startyear")]
        public string StartYear
        {
            get {return _startYear;}
            set {_startYear = value;}
        }
        #endregion

        #region EndYear Property (string)
        private string _endYear;
        [JsonProperty(PropertyName = "endyear")]
        public string EndYear
        {
            get {return _endYear;}
            set {_endYear = value;}
        }
        #endregion
    }
}
