using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList_App.Classes;
using Plugin.Media;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;



namespace WishList_App 
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddWishList : ContentPage
    {
        public AddWishList()
        {
            InitializeComponent();
        }


        public async void AddGift_Clicked(object sender, EventArgs e)
        {
            
            if (Titles.Text == string.Empty)
            {
                await DisplayAlert("Alert", "Enter title of Wish List", "OK");
            }
            else
            {
                WishList wishList = new WishList()
                {
                    Title = Titles.Text,
                    MyImage = ReadFile("storage/emulated/0/Android/data/com.companyname.wishlist_app/files/Pictures/Sample/test.jpg"),
                    ImageFilePath = "storage/emulated/0/Android/data/com.companyname.wishlist_app/files/Pictures/Sample/test.jpg",
                    Description = Description.Text,
                    Price = decimal.Parse(Price.Text),
                    Currancy = Currancy.SelectedItem.ToString(),
                    PasteLink = PasteLink.Text
                    




                };
                using (SQLiteConnection connect = new SQLiteConnection(App.filePath))
                {
                    connect.CreateTable<WishList>();

                    int rowsAdded = connect.Insert(wishList);
                }

            }


           
        }

        public byte[] ReadFile(string filePath)
        {
            byte[] data = null;

            FileInfo finfo = new FileInfo(filePath);
            long numbytes = finfo.Length;

            FileStream fstream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fstream);

            data = br.ReadBytes((int)numbytes);

            return data;
        }



        public void Clear_Clicked(object sender, EventArgs e)
        {
            WishList wishList = new WishList()
            {
                Title = Titles.Text = string.Empty,
                Description = Description.Text = string.Empty,
                Price = decimal.Parse(Price.Text = "0.00"),
                //Currancy = Currancy.SelectedItem.ToString(),
                PasteLink = PasteLink.Text = string.Empty

            };
        }

        private async void TP_Clicked(object sender, System.EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            MyImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        public async void CFG_Clicked(object sender, EventArgs e)
        {
           
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });


                if (file == null)
                    return;

                MyImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }
    }




}
    
