using MongoDB.Bson;


namespace MongoQuery
{
    /// <summary>
    /// Операция аггрегации
    /// </summary>
    public class Aggregate : DocumentOperator
    {

        public Aggregate(string collectionName)
        {
            Name = "aggregate";
            AddKeyValue(Name, collectionName);
        }

        public MongoOperator Add<T>(T mongoOp) where T: MongoOperator, IAggregateOperator
        {
            return AddOperator(mongoOp);
        }

        public new BsonDocument ToDocument()
        {
            return Data as BsonDocument;
        }
    }
}