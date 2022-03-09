using MongoDB.Bson;


namespace MongoQuery
{
    /// <summary>
    /// Класс оператора, представляющего собой BsonDocument
    /// </summary>
    public abstract class DocumentOperator : MongoOperator
    {
        /// <summary>
        /// Данные оператора
        /// </summary>
        protected override BsonValue Data { get; } = new BsonDocument();

        /// <summary>
        /// 
        /// </summary>
        protected override MongoOperator AddOperator(MongoOperator mongoOp)
        {
            if (Level > mongoOp.Level)            
                (Data as BsonDocument).AddRange(mongoOp.ToDocument());
            
            return this;
        }

        protected MongoOperator AddKeyValue(string name, BsonValue value)
        {
            (Data as BsonDocument).Add(name, value);
            return this;
        }
    }
}