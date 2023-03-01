using Domain.Interfaces.Business;

namespace Domain.Entities
{
    public class Grouping : Expression
    {
        public Expression expression;

        public Grouping(Expression expression) {
            this.expression = expression;
        }

        public override dynamic Accept(ExpressionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
