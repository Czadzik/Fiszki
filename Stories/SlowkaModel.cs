using System.Windows.Media;

namespace Stories
{
    
        public class SlowkaModel
        {
            
            public int id { get; set; }
            public string AngName { get; set; }
            public string OtherAngMeaning { get; set; }
            public string PolName { get; set; }
            public byte[] obraz { get; set; }
            public string tag { get; set; }
        }
        public class ImaglistModel
        {
            
            public int id { get; set; }
            public string AngName { get; set; }
            public string OtherAngMeaning { get; set; }
            public string PolName { get; set; }
            public ImageSource obraz { get; set; }
            public string tag { get; set; }
        public ImaglistModel(int _id,string _ang,string _pol,ImageSource _img,string _tag,string _OtherAngMeaning)
        {
            id = _id;
            AngName = _ang;
            PolName = _pol;
            obraz = _img;
            tag = _tag;
            OtherAngMeaning = _OtherAngMeaning;
        }
        }
        
    }