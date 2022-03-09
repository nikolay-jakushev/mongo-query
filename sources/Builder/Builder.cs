using MongoDB.Bson;
using MongoQuery.Query;
using System;
using System.Collections.Generic;




namespace MongoQuery
{
    public class Builder
    {
        private QueryBase queryBase = new();

        /// <summary>
        /// Метод для агрегации коллекций.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="pipeline"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public BsonDocument Aggregate(string collection, List<BsonValue> pipeline, int size)
        {
            BsonDocument cursor = queryBase.AddOperator("batchSize", size);
            
            BsonDocument aggregate = new();
            aggregate.Add("aggregate", collection);
            aggregate.Add("pipeline", queryBase.Array(pipeline));
            aggregate.Add("cursor", cursor);

            return aggregate;
        }

        /// <summary>
        /// The update command modifies documents in a collection.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="updates"></param>
        /// <returns></returns>
        public BsonDocument Update(string collection, List<ObjectQuery> updates)
        {
            BsonDocument update = new();
            update.Add("update", collection);
            update.Add("updates", queryBase.AddOperator(updates));

            Console.WriteLine(update.ToString());

            return update;
        }

        /// <summary>
        /// The insert command inserts one or more documents and returns a document containing the status of all inserts.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="documents"></param>
        /// <returns></returns>
        public BsonDocument Insert(string collection, List<BsonValue> documents, bool ordered = true)
        {
            BsonDocument insert = new();
            insert.Add("insert", collection);
            insert.Add("documents", queryBase.Array(documents));
            insert.Add("ordered", ordered);

            Console.WriteLine(insert.ToString());

            return insert;
        }

        /// <summary>
        /// The delete command removes documents from a collection.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="deletes"></param>
        /// <returns></returns>
        public BsonDocument Delete(string collection, List<ObjectQuery> deletes)
        {
            BsonDocument delete = new();
            delete.Add("delete", collection);
            delete.Add("deletes", queryBase.AddOperator(deletes));

            Console.WriteLine(delete.ToString());

            return delete;
        }

        public BsonDocument Find(string collection, int batchSize = int.MaxValue)
        {
            BsonDocument find = new();
            find.Add("find", collection);
            find.Add("batchSize", batchSize);

            Console.WriteLine(find.ToString());

            return find;
        }

        public BsonDocument Find(string collection, List<BsonElement> filter = null, int batchSize = int.MaxValue)
        {
            BsonDocument filter1 = queryBase.AddOperator("filter", filter);
            BsonDocument find = new();
            find.Add("find", collection);
            find.AddRange(filter1);            
            find.Add("batchSize", batchSize);

            Console.WriteLine(find.ToString());

            return find;
        }

        public BsonDocument Find(string collection, List<BsonElement> filter = null, List<BsonElement> projection = null, int batchSize = int.MaxValue)
        {            
            BsonDocument filter1 = queryBase.AddOperator("filter", filter);
            BsonDocument container = queryBase.AddOperator("projection", projection);
            BsonDocument find = new();
            find.Add("find", collection);
            find.AddRange(filter1);
            find.AddRange(container);
            find.Add("batchSize", batchSize);

            Console.WriteLine(find.ToString());

            return find;
        }

        public BsonDocument Find(string collection, BsonElement sort, List<BsonElement> filter = null, List<BsonElement> projection = null, int batchSize = int.MaxValue)
        {
            BsonDocument filter1 = queryBase.AddOperator("filter", filter);
            BsonDocument container = queryBase.AddOperator("projection", projection);
            BsonDocument sortContainer = queryBase.AddOperator("sort", sort);

            BsonDocument find = new();
            find.Add("find", collection);
            find.AddRange(filter1);
            find.AddRange(container);
            find.AddRange(sortContainer);
            find.Add("batchSize", batchSize);

            Console.WriteLine(find.ToString());

            return find;
        }

    }
}
