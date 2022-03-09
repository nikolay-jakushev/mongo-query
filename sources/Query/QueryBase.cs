using MongoDB.Bson;
using System.Collections.Generic;




namespace MongoQuery.Query
{
    public class QueryBase : AbstractQuery
    {
        /// <summary>
        /// Left Join / Левое внешнее соединение
        /// </summary>
        /// <param name="fromCollection"></param>
        /// <param name="localField"></param>
        /// <param name="foreignField"></param>
        /// <param name="outPutField"></param>
        /// <returns></returns>
        public BsonDocument LookUp(string fromCollection, string localField, string foreignField, string outPutField)
        {
            BsonDocument param = new BsonDocument();
            param.Add("from", fromCollection);
            param.Add("localField", localField);
            param.Add("foreignField", foreignField);
            param.Add("as", outPutField);

            BsonDocument lookup = new();
            lookup.Add("$lookup", param);

            return lookup;
        }
        
        public BsonDocument AddOperator(string action, List<string> value)
        {
            BsonArray container = new();
            container.AddRange(value);
            BsonDocument query = new();
            query.Add(action, container);
            return query;
        }

    }
}
