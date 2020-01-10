using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;
using System.Drawing;

namespace WishList_App.Converters
{
    public class BinaryToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            byte[] byteArrayIn;
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, parameter);
                byteArrayIn = ms.ToArray();
            }
           
            using (var ms = new MemoryStream(byteArrayIn))
            {
                
                return System.Drawing.Image.FromStream(ms);
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
