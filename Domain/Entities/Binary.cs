namespace Domain.Entities
{
    public class Binary
    {
        private Expression left;
        private Token op;
        private Expression right;

        public Binary(Expression left, Token op, Expression right) {
            this.left = left;
            this.op = op;
            this.right = right;
        }
    }
}
