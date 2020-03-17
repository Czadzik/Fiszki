using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Stories
{
    public static class ChoseImage
    {
        private static string [] PolWordlArry;
        private static string [] EngWordlArry;
        private static ImageSource [] ImgWordlArry;
        public static string [] BackPolWordlArry(List<ImaglistModel> pictureList ,string _tag )
        {
            var PolWords= pictureList.Where(v=>v.tag==_tag).Select(c => c.PolName);
            PolWordlArry=new string[PolWords.Count()];
            int i = 0;
            foreach (var item in PolWords)
            {
                PolWordlArry[i]= item;
                i++;
            }

            return PolWordlArry;
        }

 
        public static ImageSource[] SelectedImage(List<ImaglistModel> pictureList, string _tag,int _id)
        {
           var ImageSource = pictureList.Where(v=>v.tag==_tag).Select(c => c.obraz);
           ImgWordlArry=new ImageSource[ImageSource.Count()];
           int i = 0;
           foreach (var item in ImageSource)
           {
               ImgWordlArry[i]= item; 
               i++;
           }

           return ImgWordlArry;


        }
        //TODO Zrobić ladowanie po id i tagu bez bledu
       //  public static string SelectedWordInPol(List<ImaglistModel> pictureList, string _tag, int _id)
       //  {
       //    pictureList.Where(v=>v.tag==_tag).Select(c => c.PolName);
       //    // foreach (var VARIABLE in PolWord)
       //    // {
       //    //     PolWord[1];
       //    // }
       //  //  return 
       // }
        public static string [] SelectedWordInEng(List<ImaglistModel> pictureList, string _tag, int _id)
        {
            var EngWord= pictureList.Where(v=>v.tag==_tag).Select(c => c.AngName);
            EngWordlArry = new string[EngWord.Count()];
            int i = 0;
            foreach (var item in EngWord)
            {
                EngWordlArry[i]= item; 
                i++;
            }

            return EngWordlArry;
        } 
    }
}