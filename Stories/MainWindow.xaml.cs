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
          TestAddingToBase.Test();

          List<ImageSource> ImageLoaded=new List<ImageSource>();
          ImageLoaded = LoadImage.LoadImageFromDataBase();
          ShowImageXML.Source = ImageLoaded.First();

        }
       


       
        private void Zmien_W_Przód_Click(object sender, RoutedEventArgs e)
        {
            //GetNextSibling();
        }


    }
}
