using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BLS_Sniffer
{
	/// <summary>
	/// Interaction logic for TexasVisual.xaml
	/// </summary>
	public partial class TexasVisual : Window
	{
		public TexasVisual()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}
        int interaction = 0;
		private void StartAnimation(object sender, System.Windows.Input.KeyEventArgs e)
		{
            if (interaction == 0)
            {
                ((Storyboard)this.FindResource("NegativeBlocks")).Begin(); 
                
            }
			// TODO: Add event handler implementation here.
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (interaction == 0)
            {
                ((Storyboard)this.FindResource("NegativeBlocks")).Begin();
            } else if (interaction == 1)
            {
                ((Storyboard)this.FindResource("NegativeText")).Begin();
            }
            else if (interaction == 2)
            {
                ((Storyboard)this.FindResource("PositiveBlocks")).Begin();
            }
            else if (interaction == 3)
            {
                ((Storyboard)this.FindResource("TexasBlock")).Begin();
            }
            else if(interaction == 4)
            {
                ((Storyboard)this.FindResource("LabelStuff")).Begin();
            }
            else if (interaction == 5)
            {
                ((Storyboard)this.FindResource("LabelStuff2")).Begin();
            }
            interaction++;
        }
	}
}