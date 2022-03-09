


namespace MongoQuery
{

    public interface IAggregateOperator
    {        
        /// <summary>
        /// Добавление оператора аггрегации
        /// </summary>
        public MongoOperator Add<T>(T mongoOp) where T : MongoOperator, IAggregateOperator;
    }
}