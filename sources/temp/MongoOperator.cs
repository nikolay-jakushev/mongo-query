using MongoDB.Bson;


namespace MongoQuery
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MongoOperator : IMongoOperator
    {
        /// <summary>
        /// Данные оператора
        /// </summary>
        protected abstract BsonValue Data { get; }

        /// <summary>
        /// Имя оператора
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Уровень оператора
        /// </summary>
        public OperatorLevel Level { get; protected set; } = OperatorLevel.Unknown;        

        /// <summary>
        /// </summary>
        public BsonDocument ToDocument()
        {
            return new(Name, Data);
        }

        /// <summary>
        /// Добавление дочернего оператора
        /// </summary>
        protected abstract MongoOperator AddOperator(MongoOperator mongoOp);
    }
}