using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Image = System.Drawing.Image;

namespace Ficzki
{
    static class  LoadImage
    {
        public static List<byte[]> ByteLoad { get; set; }
        public static List<Image> ImageLoaadImage { get; set; }
        public static List<ImageSource> ImageLoad { get; set; }
        static MongoCrud db = new MongoCrud("MangoStories");

     static public List<ImaglistModel> LoadImageFromDataBase()
        {
            
            //wczytuję obrazy z Bazy w formie tablicy bitow
            var allList = db.LoadRecords<SlowkaModel>("words");
           
              ByteLoad = new List<byte[]>();
            ImageLoaadImage = new List<Image>();
            //wyviąfam tablice bitów ze zmiennej
            foreach (var item in allList)
            {
                ByteLoad.Add(item.obraz);
            }

            //zamieniam tablice bitów na obrazy
            foreach (var item in ByteLoad)
            {
                ImageLoaadImage.Add(byteArrayToImage(item));
            }

            int i = 0;
            BitmapImage[] bitmapArry = new BitmapImage[allList.Select(x => x).Count()];

         

            //zapisuje obrazy jak bitmapy do tablicy
            foreach (var item in ImageLoaadImage)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    // Save to the stream
                    BitmapImage bitmap = new BitmapImage();

                    item.Save(stream, ImageFormat.Jpeg);

                    // Rewind the stream
                    stream.Seek(0, SeekOrigin.Begin);

                    // Tell the WPF BitmapImage to use this stream
                
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    bitmapArry[i] = bitmap;
                    i++;
                }
            }

            //tablice bitmap zmieniam na listę bitmap
            ImageLoad = new List<ImageSource>();
            i = 0;
            foreach (var item in bitmapArry)
            {
                ImageLoad.Add(bitmapArry[i]);
                i++;
            }
         List< ImaglistModel> ReadyList=  ParsDataBaseFormatToProgramForma.ParseAllList(allList);
          ReadyList= ParsDataBaseFormatToProgramForma.ParseImage(ImageLoad, ReadyList);
           


            return ReadyList;
       
        }

       
        //zamienia tablice bitow na obrazy
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}