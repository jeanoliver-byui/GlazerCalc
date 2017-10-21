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

        //private double heigth;
        //private double woodLength;
        //private double glassArea;

        public displayQuote()
        {
            this.InitializeComponent();
        }

        public displayQuote(double width, double heigth, double woodLength, double glassArea)
        {
            Width = width;
            this.heigth = heigth;
            this.woodLength = woodLength;
            this.glassArea = glassArea;
        }

        //public displayQuote(double width, double heigth, double woodLength, double glassArea)
        //{
        //    widthQuoteDetailsTextBox.Text = width.ToString();
        //    heigthQuoteDetailsTextBox.Text = heigth.ToString();
        //    woodLengthQuoteDetails.Text = "The length of the wood is " +
        //        woodLength.ToString() + " feet";
        //    //this.glassArea = glassArea;
        //}
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Quote quote = e.Parameter as Quote;

            widthQuoteDetailsTextBox.Text = quote.width.ToString();
            heigthQuoteDetailsTextBox.Text = quote.heigth.ToString();
            woodLengthQuoteDetails.Text = "The length of the wood is " + quote.woodLength.ToString()
                                          + " feet";
            glassAreaQuoteDetails.Text = "The area of the glass is " + quote.glassArea.ToString()
                                          + " square metres";
            
            //tintDisplay.Text = order.Tint;
            //amountDisplay.Text = order.Amount.ToString();
            //dateDisplay.Text = order.Date.ToString();
        }

    }
}
