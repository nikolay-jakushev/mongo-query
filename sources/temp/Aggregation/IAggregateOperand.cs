


namespace MongoQuery
{

    /// <summary>
    /// Операнд аггрегации (lookup, pipeline, match, etc)
    /// </summary>
    public interface IAggregateOperand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="implOperator"></param>
        /// <returns></returns>
        public MongoOperator Add<T>(T implOperator) where T : MongoOperator;
    }
}