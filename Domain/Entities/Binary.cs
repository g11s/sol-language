using Domain.Interfaces.Business;

namespace Domain.Entities
{
    public class Binary : Expression
    {
        public Expression left;
        public Token op;
        public Expression right;

        public Binary(Expression left, Token op, Expression right) {
            this.left = left;
            this.op = op;
            this.right = right;
        }

        public override dynamic Accept(ExpressionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
