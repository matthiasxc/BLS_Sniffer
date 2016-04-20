using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BLS_Sniffer
{
    /// <summary>
    /// Interaction logic for EmploymentByState.xaml
    /// </summary>
    public partial class EmploymentByState : Window
    {
        private Dictionary<string, double> JobDeltaByState = new Dictionary<string, double>();
        public EmploymentByState()
        {
            InitializeComponent();
        }

        private void populateData(){
             JobDeltaByState["Texas"]=1282554;
             JobDeltaByState["Florida"]=	211200;
             JobDeltaByState["California"]=	172353;
             JobDeltaByState["Virginia"]=	135365;
             JobDeltaByState["Minnesota"]=	88645;
             JobDeltaByState["North Carolina"]=	80046;
             JobDeltaByState["Utah"]=	62999;
             JobDeltaByState["Oklahoma"]=	56921;
             JobDeltaByState["Louisiana"]=	45304;
             JobDeltaByState["North Dakota"]=	39382;
             JobDeltaByState["South Carolina"]=	39146;
             JobDeltaByState["Maryland"]=	34566;
             JobDeltaByState["DC"]=	29117;
             JobDeltaByState["Nebraska"]=	28120;
             JobDeltaByState["Colorado"]=	26206;
             JobDeltaByState["Wyoming"]=	13850;
             JobDeltaByState["Idaho"]=	12064;
             JobDeltaByState["Alaska"]=	10235;
             JobDeltaByState["Hawaii"]=	8937;
             JobDeltaByState["Nevada"]=	8893;
             JobDeltaByState["Iowa"]=	7455;
             JobDeltaByState["South Dakota"]=	7417;
             JobDeltaByState["Massachusetts"]=	7206;
             JobDeltaByState["Kansas"]=	5166;
             JobDeltaByState["Montana"]=	4788;
             JobDeltaByState["Maine"]=	3773;
             JobDeltaByState["Vermont"]=	-1442;
             JobDeltaByState["New Hampshire"]=	-1499;
             JobDeltaByState["Delaware"]=	-8384;
             JobDeltaByState["Kentucky"]=	-17700;
             JobDeltaByState["West Virginia"]=	-20108;
             JobDeltaByState["Washington"]=	-22347;
             JobDeltaByState["Pennsylvania"]=	-24086;
             JobDeltaByState["Rhode Island"]=	-28479;
             JobDeltaByState["Connecticut"]=	-30807;
             JobDeltaByState["New Mexico"]=	-37783;
             JobDeltaByState["Oregon"]=	-41321;
             JobDeltaByState["Tennessee"]=	-42486;
             JobDeltaByState["Indiana"]=	-51616;
             JobDeltaByState["Wisconsin"]=	-54897;
             JobDeltaByState["Mississippi"]=	-55895;
             JobDeltaByState["Missouri"]=	-57907;
             JobDeltaByState["Arkansas"]=	-61600;
             JobDeltaByState["Alabama"]=	-92170;
             JobDeltaByState["Arizona"]=	-93497;
             JobDeltaByState["New Jersey"]=	-113057;
             JobDeltaByState["New York"]=	-160707;
             JobDeltaByState["Georgia"]=	-163940;
             JobDeltaByState["Ohio"]=	-194322;
             JobDeltaByState["Michigan"]=	-259305;
             JobDeltaByState["Illinois"] = -308958;

            int redColor = 0;
            int GreenColor = 255;

            int increment = 5;
            string XAMLstring = "<!-- The positive values --> ";
            foreach (KeyValuePair<string, double> kvp in JobDeltaByState)
            {

                 if (kvp.Value > 0)
                 {
                     Border b1 = new Border();
                     b1.Background = new SolidColorBrush(Color.FromRgb(18, 118, 3));
                     b1.Margin = new Thickness(4, 4, 4, 4);
                     b1.Height = b1.Width = Math.Sqrt((kvp.Value / 100));
                     b1.BorderThickness = new Thickness(2, 2, 2, 2);
                     b1.BorderBrush = new SolidColorBrush(Color.FromRgb(15, 15, 15));
                     XAMLstring = XAMLstring + "<!-- The positive values --> <Border Height=\"" + b1.Height + "\" Width=\"" + b1.Width + "\" /> \n";
                     PositivePanel.Children.Add(b1);

                 }
                 else
                 {
                     Border b1 = new Border();
                     b1.Background = new SolidColorBrush(Color.FromRgb(157,8, 8));
                     b1.Margin = new Thickness(4, 4, 4, 4);
                     b1.Height = b1.Width = Math.Sqrt(-(kvp.Value / 100));
                     b1.BorderThickness = new Thickness(2, 2, 2, 2);
                     XAMLstring = XAMLstring + " <!-- The negative values --> <Border Height=\"" + b1.Height + "\" Width=\"" + b1.Width + "\" /> \n\n";
                     b1.BorderBrush = new SolidColorBrush(Color.FromRgb(15, 15, 15));
                     NegativePanel.Children.Add(b1);
                 }
                     
                redColor += increment;
                GreenColor -= increment;
             }
            XAMLText.Text = XAMLstring;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            populateData();
        }
    }

    
}
