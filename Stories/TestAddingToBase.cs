using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;


namespace Stories
{
    public static class TestAddingToBase
    {
        public static void Test()
        {
            string testAngName = "dwo";
            string testPolName = "dwa";
            string inneZnacz = "drugi";

             Image obraz = Image.FromFile(@"C:\Users\Czadzik\Desktop\fff.png");
            //   ImageTo newImage=new ImageTo();
            byte[] binaryContent =ImageTo.imageToByteArray(obraz);


           
            //LoadImage DataContext=new LoadImage();
         
            MongoCrud db = new MongoCrud("MangoStories");
         //   db.InsertRecord("words", new SlowkaModel {id=2 ,AngName = testAngName, PolName = testPolName, OtherAngMeaning = inneZnacz, obraz = binaryContent });
            var LoadedImageFromDb = db.LoadRecords<SlowkaModel>("words");
            MessageBox.Show(LoadedImageFromDb.Select(x=>x).Count().ToString());
        }
       
    }
}