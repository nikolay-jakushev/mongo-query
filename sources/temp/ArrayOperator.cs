using MongoDB.Bson;


namespace MongoQuery
{
    /// <summary>
    /// Класс оператора, представляющего собой BsonDocument
    /// </summary>
    public abstract class ArrayOperator : MongoOperator
    {
        /// <summary>
        /// Данные оператора
        /// </summary>
        protected override BsonValue Data { get; } = new BsonArray();

        /// <summary>
        /// 
        /// </summary>
        protected override MongoOperator AddOperator(MongoOperator mongoOp)
        {
            if (Level > mongoOp.Level)
                (Data as BsonArray).AddRange(mongoOp.ToDocument());

            return this;
        }
    }
}