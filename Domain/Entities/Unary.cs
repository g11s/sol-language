using Domain.Interfaces.Business;

namespace Domain.Entities
{
    public class Unary : Expression
    {
        public Token op;
        public Expression right;

        public Unary(Token op, Expression right) {
            this.op = op;
            this.right = right;
        }

        public override string Accept(ExpressionVisitor visitor)
        {
            return visitor.visit(this);
        }
    }
}
