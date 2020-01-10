using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;

namespace WishList_App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage viewPage = new NavigationPage(new ViewItems());
            viewPage.IconImageSource = "home.jpg";
            viewPage.Title = "My Lists";

            NavigationPage webPage = new NavigationPage(new WebPage());
            webPage.IconImageSource = "webpage.png";
            webPage.Title = "Browser";

            NavigationPage AddWish = new NavigationPage(new AddWishList());
            AddWish.IconImageSource = "home.png";
            AddWish.Title = "Add Gift";

            //This is where you add new pages to your tab view 
            this.Children.Add(viewPage);
            this.Children.Add(webPage);
            this.Children.Add(AddWish);
        }


    }
}
