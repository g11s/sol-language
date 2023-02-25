namespace Domain.Entities
{
    public class Unary
    {
        private Token operator;
        private Expression right;

        public Unary(Token operator, Expression right) {
            this.operator = operator;
            this.right = right;
        }
    }
}
