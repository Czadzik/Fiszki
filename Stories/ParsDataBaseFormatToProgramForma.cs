using System.Collections.Generic;
using System.Windows.Media;

namespace Stories
{
    public static class ParsDataBaseFormatToProgramForma
    {
        public static List<ImaglistModel> ParseImage(List<ImageSource> ImageFromDatabase,List<ImaglistModel> List)
        {
            




            int i = 0;
            foreach (var item in ImageFromDatabase)
            {
                List[i].obraz= item;
                i++;
            }
            
            
            return List;
        }
        public static List<ImaglistModel> ParseAllList(List<SlowkaModel> BaseList)
        {
            int i = 0;
            int id;
            string ang;
            string pol;
            ImageSource image;
            string tag;
            string drugi;
            List<ImaglistModel> ReadyList = new List<ImaglistModel>();
            foreach (var item in BaseList)
            {
                id = item.id;
                ang = item.AngName;
                pol = item.PolName;
                tag = item.tag;
                drugi = item.OtherAngMeaning;
                image = default;

                ReadyList.Add(new ImaglistModel(id, ang, pol, image, tag, drugi));

            }
            return ReadyList;
        }

    }
}