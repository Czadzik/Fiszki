using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Stories
{
    class MongoCrud
    {
        private IMongoDatabase db;
         
        public MongoCrud(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }
        
        public void InsertRecord<T>(string table,T Record)
        {
            var colection = db.GetCollection<T>(table);
            colection.InsertOne(Record);
        }
        public List<T> LoadRecords<T>(string table)
        {
            var colection = db.GetCollection<T>(table);
            return colection.Find(new BsonDocument()).ToList();
        }
      

        public void UpsertRescord<T>(string table, int id, T record)
        {
            var colection = db.GetCollection<T>(table);
            var result = colection.ReplaceOne(new BsonDocument("_id", id), record, new UpdateOptions {IsUpsert = true});
        }
      

        public void DeleteRecord<T>(string table, int id)
        {
            var colection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            colection.DeleteOne(filter);
        }
     

    }
}
