using MongoDB.Bson;
using System.Collections.Generic;





namespace MongoQuery.Query
{
    public class ObjectQuery : BsonDocument
    {
        public BsonDocument Updates(BsonDocument q, BsonDocument u, bool upsert = false, bool multi = false)
        {
            BsonDocument query = new();
            query.Add("q", q);
            query.Add("u", u);
            query.Add("upsert", upsert);
            query.Add("multi", multi);
            return query;
        }

        public BsonDocument Updates(BsonDocument q, List<BsonDocument> u, bool upsert = false, bool multi = false)
        {
            BsonArray up = new();
            up.AddRange(u);
            BsonDocument query = new();
            query.Add("q", q);
            query.Add("u", up);
            query.Add("upsert", upsert);
            query.Add("multi", multi);
            return query;
        }

        public BsonDocument Deletes(BsonDocument q, int limit = 1)
        {
            BsonDocument query = new();
            query.Add("q", q);
            query.Add("limit", limit);
            return query;
        }

    }
}
