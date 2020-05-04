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
using System.Drawing;
using Image = System.Drawing.Image;


namespace Ficzki
{
    public static class TestAddingToBase
    {
        public static void Test(string _ang,string _pol,string _inne,string _tag,Image _img)
        {
            string testAngName = _ang.ToLower();
            string testPolName = _pol.ToLower();
            string inneZnacz = _inne.ToLower();
            string tag = _tag.ToLower();

            Image obraz = _img;
            //   ImageTo newImage=new ImageTo();
            byte[] binaryContent =ImageTo.imageToByteArray(obraz);


           
            //LoadImage DataContext=new LoadImage();
         
            MongoCrud db = new MongoCrud("MangoStories");
            var loadList=db.LoadRecords<SlowkaModel>("words");
            int idCount = loadList.Where(x => x.tag == _tag).Select(c => c.idTag).Count();
            idCount++;
           db.InsertRecord("words", new SlowkaModel {idTag=idCount ,AngName = testAngName, PolName = testPolName, OtherAngMeaning = inneZnacz, obraz = binaryContent,tag = tag});
            var LoadedImageFromDb = db.LoadRecords<SlowkaModel>("words");
            MessageBox.Show(LoadedImageFromDb.Select(x=>x).Count().ToString());
        }
       
    }
}