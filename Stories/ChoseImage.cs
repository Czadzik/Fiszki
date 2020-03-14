using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Stories
{
    public static class ChoseImage
    {
        public  static ImageSource ImageSource;
        public static string PolWord;
        public  static string EngWord;
        public static ImageSource SelectedImage(List<ImaglistModel> pictureList, string _tag,int _id)
        {
            return ImageSource = pictureList.Where(x => x.id == _id).Where(v=>v.tag==_tag).Select(c => c.obraz).First();
             

        }

        public static string SelectedWordInPol(List<ImaglistModel> pictureList, string _tag, int _id)
        {
           return PolWord= pictureList.Where(x => x.id == _id).Where(v=>v.tag==_tag).Select(c => c.PolName).First();
        }
        public static string SelectedWordInEng(List<ImaglistModel> pictureList, string _tag, int _id)
        {
           return EngWord= pictureList.Where(x => x.id == _id).Where(v=>v.tag==_tag).Select(c => c.AngName).First();
        } 
    }
}