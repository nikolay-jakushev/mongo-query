using MongoDB.Bson;
using System.Collections.Generic;




namespace MongoQuery.Query
{
    interface IArray
    {
        public BsonArray Array(BsonValue query);
        public BsonArray Array(List<BsonValue> query);
        public BsonArray AddOperator(ObjectQuery query);
        public BsonArray AddOperator(List<ObjectQuery> query);
    }
}
