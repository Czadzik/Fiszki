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
using System.Windows.Shapes;
using System.IO;
using System.Windows;
using Microsoft.Win32;


namespace Stories
{
    /// <summary>
    /// Interaction logic for New.xaml
    /// </summary>
    public partial class NewWindowToAdd : Window
    {
        Image myImage3 = new Image();
        public System.Drawing.Image img2;
        
        public NewWindowToAdd()
        {
            InitializeComponent();
        }

        private void Zaladuj_Click(object sender, RoutedEventArgs e)
        {
            Image a;
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                LoadImg.Source = new BitmapImage(new Uri(op.FileName));
                
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(op.FileName);
                bi3.EndInit();
                myImage3.Stretch = Stretch.Fill;
                myImage3.Source = bi3;
                MemoryStream ms = new MemoryStream(); 
                System.Windows.Media.Imaging.BmpBitmapEncoder bbe = new BmpBitmapEncoder();
                bbe.Frames.Add(BitmapFrame.Create(new Uri(myImage3.Source.ToString(),UriKind.RelativeOrAbsolute)));

                bbe.Save(ms); 
                 img2 = System.Drawing.Image.FromStream(ms);
               
            }
           
       

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            TestAddingToBase.Test(angTB.Text,PolskiTB.Text,inneTB.Text,TagTB.Text,img2);
        }
    }
}
