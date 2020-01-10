using System;
using WishList_App.Classes;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WishList_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewItems : ContentPage
    {


        public ViewItems()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection connect = new SQLiteConnection(App.filePath))
            {
                connect.CreateTable<WishList>();
                var viewP = connect.Table<WishList>().ToList();

                contentsListView.ItemsSource = viewP;
            }
        }

        public void Delete_Clicked(object sender, EventArgs e)
        {
            

            var delete = (WishList)contentsListView.SelectedItem;

            using (SQLiteConnection connect = new SQLiteConnection(App.filePath))
            {
                connect.Query<WishList>($"DELETE FROM WishList WHERE ItemID = ?", delete.ItemID);
                connect.CreateTable<WishList>();
                var WL = connect.Table<WishList>().ToList();
                contentsListView.ItemsSource = WL;
            }
        }

        
    }
}