using BLS_API_Portable.LocalUnemployment;
using BLS_API_Portable.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BLS_Sniffer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BlsService _service = new BlsService();
        List<RegionSeries> stateData = new List<RegionSeries>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetSampleSeries();
        }

        private async Task GetSampleSeries()
        {
            
            //List<string> seriesToGet = new List<string>();
            //seriesToGet.Add("LASST010000000000004");
            //seriesToGet.Add("LASST010000000000005");
            //seriesToGet.Add("LASST010000000000006");

            //LocalUnemploymentParser.PrintStateEnums();

            var rawData = await _service.GetAllLocalEmployment(2006, 2014);
            stateData = rawData;
            resultDisplay.ItemsSource = stateData;
        }

        private async Task OutputStateFiles()
        {
            var filesToExport = LocalCsvOutput.OutputByMeasure(stateData);

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            string folderBase = fbd.SelectedPath;

            foreach(KeyValuePair<string, List<List<string>>> kvp in filesToExport)
            {
                using (StreamWriter sw = new StreamWriter(folderBase + @"\" + kvp.Key +".csv"))
                {
                    foreach (List<string> rowData in kvp.Value)
                    {
                        string rowOutput = "";
                        foreach (string datum in rowData)
                        {
                            rowOutput += "\"" + datum + "\",";
                        }
                        // We probably don't even need to do this... the CSV format
                        //   is pretty robust
                        rowOutput = rowOutput.Substring(0, rowOutput.Length - 1);
                        sw.WriteLine(rowOutput);
                    }
                    sw.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OutputStateFiles();
        }
    }
}
