using System;
using System.Collections.Generic;
using System.Windows.Media;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Stories
{
    
        public class SlowkaModel
        {
            [BsonId]
            public Guid id { get; set; }
            public int idTag { get; set; }
            public string AngName { get; set; }
            public string OtherAngMeaning { get; set; }
            public string PolName { get; set; }
            public byte[] obraz { get; set; }
            public string tag { get; set; }
        }
        public class ImaglistModel
        {
            
            public int idTag { get; set; }
            public string AngName { get; set; }
            public string OtherAngMeaning { get; set; }
            public string PolName { get; set; }
            public ImageSource obraz { get; set; }
            public string tag { get; set; }
        public ImaglistModel(int _id,string _ang,string _pol,ImageSource _img,string _tag,string _OtherAngMeaning)
        {
            idTag = _id;
            AngName = _ang;
            PolName = _pol;
            obraz = _img;
            tag = _tag;
            OtherAngMeaning = _OtherAngMeaning;
        }
        
        }

        public class TagModel
        {
        
            public List<string> TagColecton { get; set; }

            public TagModel(List<SlowkaModel> WorldModel)
            {
                TagColecton =new List<string>();
                bool test=true;
                foreach (var item in WorldModel)
                {
                    //aby tagi się nie powtarzały 
                    test = true;
                    foreach (var item2 in TagColecton)
                    {
                        if (item.tag==item2)
                        {
                            test = false;
                        }
                    }

                    if (test)
                    {
                        TagColecton.Add(item.tag);
                    }
                    
                }
            }
        }
    }