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

namespace Stories
{
    class ImageViewModel
    {
        public List<byte[]> ByteLoad { get; set; }
        public List<Image> ImageLoaadImage { get; set; }
        public List<ImageSource> ImageLoad { get; set; }
        MongoCrud db = new MongoCrud("MangoStories");

        public ImageViewModel()
        {
            //wczytuję obrazy z Bazy w formie tablicy bitow
            var a = db.LoadRecords<MainWindow.SlowkaModel>("Slowka");
            ByteLoad = new List<byte[]>();
            ImageLoaadImage = new List<Image>();
            //wyviąfam tablice bitów ze zmiennej
            foreach (var item in a)
            {
                ByteLoad.Add(item.obraz);
            }

            //zamieniam tablice bitów na obrazy
            foreach (var item in ByteLoad)
            {
                ImageLoaadImage.Add(byteArrayToImage(item));
            }

            int i = 0;
            BitmapImage[] bitmapArry = new BitmapImage[a.Select(x => x).Count()];

         

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

            i = 0;
            foreach (var window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).BlueTeam.ItemsSource= ImageLoad;
                }
            }
        }

        //zamienia tablice bitow na obrazy
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}