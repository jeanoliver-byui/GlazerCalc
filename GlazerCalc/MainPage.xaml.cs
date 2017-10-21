using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            tintComboBox.Items.Add("Black");
            tintComboBox.Items.Add("Brown");
            tintComboBox.Items.Add("Blue");
            tintComboBox.SelectedIndex = 0;
        }
        //public double width { get; set; }
        //public double heigth { get; set; }
        //public double woodLength { get; set; }
        //public double glassArea { get; set; }
        //public string widthString { get; set; }
        //public string heightString { get; set; }
        

        private void quoteButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string widthString = widthTextBox.Text;
                double width = double.Parse(widthString);
                string heightString = heigthTextBox.Text;
                double heigth = double.Parse(heightString);
                double woodLength = 2 * (width + heigth) * 3.25;
                double glassArea = 2 * (width * heigth);

                Quote newQuote = new Quote()
                {
                    width = width,
                    heigth = heigth,
                    woodLength = woodLength,
                    glassArea = glassArea
                };
                
                displayQuote newDisplayQuote = new displayQuote(newQuote.width, newQuote.heigth,
                                                                newQuote.woodLength, newQuote.glassArea);

                this.Frame.Navigate(typeof(displayQuote), newQuote);
                
                
            }
            catch (Exception)
            {
              // MessageBox.Dialog("Check Input");
                //throw;
            }
            

        }

        private void widthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void heigthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
