using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
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

            // Set the tintComboBox values colors
            tintComboBox.Items.Add("Black");
            tintComboBox.Items.Add("Brown");
            tintComboBox.Items.Add("Blue");
            tintComboBox.SelectedIndex = 0;
        }

        //create variables
        public double width { get; set; }
        public double heigth { get; set; }
        public double woodLength { get; set; }
        public double glassArea { get; set; }
        public string widthString { get; set; }
        public string heightString { get; set; }
        public int quantity { get; set; }
        public string tintColor { get; set; }
        public string quoteDate { get; set; }

        //width keybloard event handler
        private async void width_KeyUp(object sender, KeyRoutedEventArgs e)
        {

            if (!(e.Key >= VirtualKey.Number0 && e.Key <= VirtualKey.Number9)
               && !(e.Key >= VirtualKey.NumberPad0 && e.Key <= VirtualKey.NumberPad9)
               && !(e.Key == VirtualKey.Decimal)
               && !((int)e.Key == 190)
               && !(e.Key == VirtualKey.Tab)
               && !(e.Key == VirtualKey.Enter))
            {
                ContentDialog widthError = new ContentDialog()
                {
                    Title = "Message",
                    Content = "The width must be a number.",
                    CloseButtonText = "Ok"
                };
                await widthError.ShowAsync();
                widthTextBox.Text = "";
            }
            else
            {
                if (e.Key == VirtualKey.Enter)
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Down);

            }
        }

        //heigth keybloard event handler
        private async void heigth_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!(e.Key >= VirtualKey.Number0 && e.Key <= VirtualKey.Number9)
              && !(e.Key >= VirtualKey.NumberPad0 && e.Key <= VirtualKey.NumberPad9)
              && !(e.Key == VirtualKey.Decimal)
              && !((int)e.Key == 190)
              && !(e.Key == VirtualKey.Tab)
              && !(e.Key == VirtualKey.Enter))
            {
                ContentDialog heigthError = new ContentDialog()
                {
                    Title = "Message",
                    Content = "The heigth must be a number.",
                    CloseButtonText = "Ok"
                };
                await heigthError.ShowAsync();
                heigthTextBox.Text = "";
            }
            else
            {
                if (e.Key == VirtualKey.Enter)
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Down);

            }
        }

        private async void quoteButton_Click(object sender, RoutedEventArgs e)
        {
            //Validating width input
            try
            {
                //get width
                widthString = widthTextBox.Text;
                width = double.Parse(widthString);
            }
            catch (Exception)
            {
                ContentDialog error = new ContentDialog()
                {
                    Title = "Message",
                    Content = "Please, enter width value.",
                    CloseButtonText = "Ok"
                };
                await error.ShowAsync();
                widthTextBox.Text = "";
                return;
               
            }

            //Validating heigth input
            try
            {
                //get heigth
                heightString = heigthTextBox.Text;
                heigth = double.Parse(heightString);
            }
            catch (Exception)
            {
                ContentDialog error = new ContentDialog()
                {
                    Title = "Message",
                    Content = "Please, enter heigth value.",
                    CloseButtonText = "Ok"
                };
                await error.ShowAsync();
                heigthTextBox.Text = "";
                return;
            }
                // woodlength and glassArea calculation
                woodLength = 2 * (width + heigth) * 3.25;
                glassArea = 2 * (width * heigth);
                tintColor = Convert.ToString(tintComboBox.SelectedValue);
                quantity = Convert.ToInt32(quantitySlider.Value);
                quoteDate = DateTime.Now.ToString(); ;

            // new quote
            Quote newQuote = new Quote()
            {
                width = width,
                heigth = heigth,
                woodLength = woodLength,
                glassArea = glassArea,
                tintColor = tintColor,
                quantity = quantity,
                quoteDate = quoteDate
            };

            //pass new quote values to displayQuote
            displayQuote newDisplayQuote = new displayQuote(newQuote.width, newQuote.heigth, newQuote.woodLength,
                                        newQuote.glassArea, newQuote.tintColor, newQuote.quantity, newQuote.quoteDate);
            // show new displayQuote
            this.Frame.Navigate(typeof(displayQuote), newQuote);
        }

       
    }
}