


namespace MongoQuery
{

    public class Pipeline : ArrayOperator, IAggregateOperator
    {
        public Pipeline()
        {
            Name = "pipeline";
            Level = OperatorLevel.Primary;
        }

        public MongoOperator Add<T>(T mongoOp) where T: MongoOperator, IAggregateOperator
        {
            return AddOperator(mongoOp);
        }
    }
}