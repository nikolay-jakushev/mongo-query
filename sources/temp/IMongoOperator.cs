using MongoDB.Bson;


namespace MongoQuery
{
    /// <summary>
    /// Интерфейс оператора в MongoDB
    /// </summary>
    public interface IMongoOperator
    {
        /// <summary>
        /// Уровень оператора (необходим для соблюдения иерархии при построения запроса)
        /// </summary>
        public OperatorLevel Level { get; }

        /// <summary>
        /// Возвращает данные оператора в виде Bson-документа, в формате { name: data }
        /// </summary>
        public BsonDocument ToDocument();
    }
}