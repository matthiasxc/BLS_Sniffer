using BLS_API_Portable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable
{
    public interface IBLSSeriesType
    {
        string GetSeriesID();        
        string ParseSeriesID(string idInput); 
    }
}
