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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GlazerCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class displayQuote : Page
    {
        private double heigth;
        private double woodLength;
        private double glassArea;
        private int quantity;
        private string tintColor;
        private string quoteDate;

        public displayQuote()
        {
            this.InitializeComponent();
        }

        public displayQuote(double width, double heigth, double woodLength, double glassArea,
            string tintColor, int quantity, string quoteDate)
        {
            Width = width;
            this.heigth = heigth;
            this.woodLength = woodLength;
            this.glassArea = glassArea;
            this.tintColor = tintColor;
            this.quantity = quantity;
            this.quoteDate = quoteDate;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Quote quote = e.Parameter as Quote;

            widthQuoteDetailsTextBox.Text = quote.width.ToString();
            heigthQuoteDetailsTextBox.Text = quote.heigth.ToString();
            colorTextBox.Text = quote.tintColor;
            quantityTextBox.Text = quote.quantity.ToString();
            DateTextBox.Text = quote.quoteDate;
            woodLengthQuoteDetails.Text = "The length of the wood is " + quote.woodLength.ToString()
                                          + " feet";
            glassAreaQuoteDetails.Text = "The area of the glass is " + quote.glassArea.ToString()
                                          + " square meters";
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the main page.
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
