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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string testAngName = "dwo";
            string testPolName = "dwa";
            string inneZnacz = "drugi";
            Image obraz = Image.FromFile(@"C:\Users\Czadzik\Desktop\fff.png");
            byte[] binaryContent = imageToByteArray(obraz);


           
             DataContext=new ImageViewModel();
             
            MongoCrud db = new MongoCrud("MangoStories");
         //  db.InsertRecord("words", new SlowkaModel {id=2 ,AngName = testAngName, PolName = testPolName, OtherAngMeaning = inneZnacz, obraz = binaryContent });
            var a = db.LoadRecords<SlowkaModel>("words");
            MessageBox.Show(a.Select(x=>x).Count().ToString());




        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }


       
        private void Zmien_W_Przód_Click(object sender, RoutedEventArgs e)
        {
            //GetNextSibling();
        }


    }
}
