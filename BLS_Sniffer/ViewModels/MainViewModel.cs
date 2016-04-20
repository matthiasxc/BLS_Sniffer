using BLS_API_Portable.Models;
using BLS_API_Portable.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLS_Sniffer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private BlsService _blsService = new BlsService();

        public MainViewModel() { }

        #region CurrentSource (ObservableCollection<BlsSeries>)
        private ObservableCollection<BlsSeries> _currentSource = new ObservableCollection<BlsSeries>();
        public ObservableCollection<BlsSeries> CurrentSource
        {
            get { return _currentSource; }
            set
            {
                _currentSource = value;
                NotifyPropertyChanged("CurrentSource");
            }
        }
        #endregion

        #region SelectedSeries (BlsSeries)
        private BlsSeries _selectedSeries = null;
        public BlsSeries SelectedSeries
        {
            get { return _selectedSeries; }
            set
            {
                _selectedSeries = value;
                NotifyPropertyChanged("SelectedSeries");
            }
        }
        #endregion

        public async Task GetAllLocalUnemployment()
        {

        }

        public async Task ExportData()
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "csv |*.csv";
            saveFileDialog1.Title = "Save data to CSV";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                List<string> exportBuilder = new List<string>();
                // Go through each series, grab all the Employment, state by state
                if (CurrentSource != null && CurrentSource.Count > 1) { 
                    var baseColumn = CurrentSource[0];
                    exportBuilder.Add("Month/Year," + baseColumn.Description);
                    foreach (BLSDataPoint bdp in baseColumn.data)
                    {
                        //exportBuilder.Add()
                    }
                }



                //System.IO.File.WriteAllLines()
                
                // Saves the Image via a FileStream created by the OpenFile method.
                //System.IO.FileStream fs =
                //   (System.IO.FileStream)saveFileDialog1.OpenFile();
                //fs.Close();

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
    }
}
