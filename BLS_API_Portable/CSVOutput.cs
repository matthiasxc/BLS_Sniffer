using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_API_Portable
{
    public static class CSVOutput
    {
        public static string ConvertToCSV(List<List<string>> sourceData)
        {
            StringBuilder returnValue = new StringBuilder();
            foreach (List<string> rowData in sourceData)
            {
                string rowOutput = "";
                foreach (string datum in rowData)
                {
                    rowOutput += "\"" + datum + "\",";
                }
                // We probably don't even need to do this... the CSV format
                //   is pretty robust
                rowOutput = rowOutput.Substring(0, rowOutput.Length - 1);
                returnValue.AppendLine(rowOutput);
            }

            return returnValue.ToString();
        }
    }
}
