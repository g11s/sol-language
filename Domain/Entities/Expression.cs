using Domain.Interfaces.Business;

namespace Domain.Entities
{
    public abstract class Expression
    {
        public abstract string Accept(ExpressionVisitor visitor);
    }
}
