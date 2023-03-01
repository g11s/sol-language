using Domain.Interfaces.Business;

namespace Domain.Entities
{
    public class Literal : Expression
    {
        public dynamic value;

        public Literal(dynamic value) {
            this.value = value;
        }

        public override dynamic Accept(ExpressionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
