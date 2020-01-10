using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WishList_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPage : ContentPage
    {
        public WebPage()
        {
            InitializeComponent();

            

            url.Text = "https://www.google.com";
            Browser.Source = url.Text;

           


        }

        public void Go_Clicked(object sender, EventArgs e)
        {
            Browser.Source = url.Text;

        }
        public void Forward_Clicked(object sender, EventArgs e)
        {
            if (Browser.CanGoForward)
            {
                Browser.GoForward();
                
               
            }
        }

        public void  Back_Clicked(object sender, EventArgs e)
        {

            if (Browser.CanGoBack)
            {
                Browser.GoBack();
            }

        }

        public void Browser_Navigating(object sender, WebNavigatingEventArgs e)
        {
            LoadingLabel.IsVisible = true;
            url.Text = e.Url;
            
        }
        
        private void Browser_Navigated(object sender, WebNavigatedEventArgs e)
        {
          
            LoadingLabel.IsVisible = false;
        }
    }

   
}