


namespace MongoQuery
{
    /// <summary>
    /// Уровень оператора (необходим для соблюдения иерархии операторов в запросе)
    /// </summary>
    public enum OperatorLevel
    {        
        /// <summary>
        /// Вторичный
        /// </summary>
        Secondary,        
        /// <summary>
        /// Первичный (root)
        /// </summary>
        Primary,
        /// <summary>
        /// Неизвестный уровень (заглушка для абстрактных классов, реализующих IMongoOperator)
        /// </summary>
        Unknown
    }
}