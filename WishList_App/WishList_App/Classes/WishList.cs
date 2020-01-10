using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WishList_App.Classes
{
    class WishList
    {
        [PrimaryKey, AutoIncrement]
        public int ItemID { get; set; }
        public string Title { get; set; }

       public byte[] MyImage { get; set; }

        public string ImageFilePath { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Currancy { get; set; }

        public string PasteLink { get; set; }
    }
   }
