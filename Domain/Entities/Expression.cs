using Domain.Interfaces.Business;

namespace Domain.Entities
{
    public abstract class Expression
    {
        public abstract dynamic Accept(ExpressionVisitor visitor);
    }
}
