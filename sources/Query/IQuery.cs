using MongoDB.Bson;
using System.Collections.Generic;




namespace MongoQuery.Query
{
    interface IQuery
    {
        public BsonDocument AddOperator(string action, BsonValue field);
        public BsonDocument AddOperator(string action, BsonElement query);
        public BsonDocument AddOperator(string action, List<BsonElement> value);
    }
}
