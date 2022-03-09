using MongoDB.Bson;
using System.Collections.Generic;




namespace MongoQuery.Query
{
    public abstract class AbstractQuery : BsonDocument, IQuery, IArray
    {
        /// <summary>
        /// Метод для добавления значений поля {"field":"value"}
        /// </summary>
        /// <param name="action"> "field" - "$limit", "$skip", "$count" и т.д </param>
        /// <param name="value"> "value" </param>
        /// <returns></returns>
        public BsonDocument AddOperator(string action, BsonValue value)
        {
            BsonDocument container = new();
            container.Add(action, value);
            return container;
        }

        /// <summary>
        /// Метод для добавления элементов вида "action": {"field":"value"} 
        /// </summary>
        /// <param name="action"> "$sort" и т.п </param>
        /// <param name="value"> {"field":"value"} </param>
        /// <returns></returns>
        public BsonDocument AddOperator(string action, BsonElement value)
        {
            BsonDocument container = new();
            container.Add(value);
            BsonDocument query = new();
            query.Add(action, container);
            return query;
        }

        /// <summary>
        /// Метод для добавления списка элементов вида action:{"value", "value", "value", "value", } или action: {"field":"value" , "field":"value" , ... }
        /// </summary>
        /// <param name="action"> "filter", "projection", "$eq", "$gte", "$lte", "$lt"..., "$project", "$sort", "$match" и т.д </param>
        /// <param name="value"></param>
        /// <returns></returns>
        public BsonDocument AddOperator(string action, List<BsonElement> value)
        {
            BsonDocument container = new();
            container.AddRange(value);
            BsonDocument query = new();
            query.Add(action, container);

            return query;
        }

        /// <summary>
        /// Метод для добавления в массив
        /// </summary>
        /// <param name="value"> {"$andOr", "$pipeline"} </param>
        /// <returns></returns>
        public BsonArray Array(BsonValue value)
        {
            BsonArray pipeline = new();
            pipeline.Add(value);
            return pipeline;
        }

        /// <summary>
        /// Метод для добавления в массив список объектов
        /// </summary>
        /// <param name="value">{"$andOr", "$pipeline"}</param>
        /// <returns></returns>
        public BsonArray Array(List<BsonValue> value)
        {
            BsonArray pipeline = new();
            pipeline.AddRange(value);
            return pipeline;
        }

        /// <summary>
        /// Метод для обновления и удаления объектов
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public BsonArray AddOperator(ObjectQuery query)
        {
            BsonArray updates = new BsonArray();
            updates.Add(query);
            return updates;
        }

        /// <summary>
        /// Метод для обновления и удаления объектов
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public BsonArray AddOperator(List<ObjectQuery> query)
        {
            BsonArray updates = new BsonArray();
            updates.AddRange(query);
            return updates;
        }
    }
}
