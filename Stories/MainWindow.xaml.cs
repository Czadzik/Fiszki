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
    public partial class MainWindow
    {
        private string[] LoadedArryPolWord;
        private string[] LoadedArryEngWord;
        private ImageSource[] LoadedArryImgWord;
        public int current_id=0;
        public string current_tag;
        List<ImaglistModel> ImageLoaded = new List<ImaglistModel>();
        MongoCrud db = new MongoCrud("MangoStories");

        public MainWindow()
        {

            InitializeComponent();
            var ListDatabesObject = db.LoadRecords<SlowkaModel>("words");
            DataContext = new TagModel(ListDatabesObject);
            // TestAddingToBase.Test();
            ImageLoaded = LoadImage.LoadImageFromDataBase();


        }




        private void Załaduj_Click(object sender, RoutedEventArgs e)
        {
            current_id = 0;
            current_tag = tag.Text;
            //current_id = Int32.Parse(id.Text);
            LoadedArryPolWord = ChoseImage.BackPolWordlArry(ImageLoaded, current_tag);
            LoadedArryImgWord = ChoseImage.SelectedImage(ImageLoaded, current_tag, current_id);
            LoadedArryEngWord = ChoseImage.SelectedWordInEng(ImageLoaded, current_tag, current_id);
            PolWordTB.Text = LoadedArryPolWord[current_id];

            EngWordTB.Text=LoadedArryEngWord[current_id];
               
          
            ShowImageXML.Source=LoadedArryImgWord[current_id];
          
          
        }
        private void Zmien_W_Przód_Click(object sender, RoutedEventArgs e)
        {
            var ListDatabesObject = db.LoadRecords<SlowkaModel>("words").Where(x=>x.tag==current_tag).Count();
            if ((ListDatabesObject -1)> current_id)
            {
                current_id++;
            }
            EngWordTB.Text = LoadedArryEngWord[current_id];
            PolWordTB.Text = LoadedArryPolWord[current_id];

            ShowImageXML.Source = LoadedArryImgWord[current_id];

        }

        private void Zmien_W_Tyl_Click(object sender, RoutedEventArgs e)
        {
            var ListDatabesObject = db.LoadRecords<SlowkaModel>("words").Where(x=>x.tag==current_tag).Count();
            if ( current_id>0)
            {
                current_id--;
            }
            EngWordTB.Text = LoadedArryEngWord[current_id];
            PolWordTB.Text = LoadedArryPolWord[current_id];

            ShowImageXML.Source = LoadedArryImgWord[current_id];

        }

        private void Nowy_Click(object sender, RoutedEventArgs e)
        {
            NewWindowToAdd window = new NewWindowToAdd();
            window.Show();
        }
    }
}
      
    
