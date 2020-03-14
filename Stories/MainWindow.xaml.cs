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
        public int current_id;
        public string current_tag;
        List<ImaglistModel> ImageLoaded=new List<ImaglistModel>();
        public MainWindow()
        {
            
            InitializeComponent();
         // TestAddingToBase.Test();

     
          ImageLoaded = LoadImage.LoadImageFromDataBase();
         
         
        }
       


       
        private void Zmien_W_Przód_Click(object sender, RoutedEventArgs e)
        {
            current_id = Int32.Parse(id.Text);
            current_tag = tag.Text;
            EngWordTB.Text = ChoseImage.SelectedWordInEng(ImageLoaded, current_tag, current_id);
            PolWordTB.Text = ChoseImage.SelectedWordInPol(ImageLoaded, current_tag, current_id);

            ShowImageXML.Source = ChoseImage.SelectedImage(ImageLoaded, current_tag, current_id);
        }


    }
}
