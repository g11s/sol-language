using Domain.Entities;
using Domain.Interfaces.Business;
using System.Text;

namespace Domain.Tools
{
    public class AstPrinter : ExpressionVisitor
    {
        public string Print(Expression expression)
        {
            return expression.Accept(this);
        }

        public dynamic Visit(Binary binary)
        {
            return Parenthesize(binary.op.Lexeme,
                                binary.left, binary.right);
        }

        public dynamic Visit(Grouping grouping)
        {
            return Parenthesize("group", grouping.expression);
        }

        public dynamic Visit(Literal literal)
        {
            if (literal.value == null) return "nil";
            return literal.value.ToString();
        }

        public dynamic Visit(Unary unary)
        {
            return Parenthesize(unary.op.Lexeme, unary.right);
        }

        private string Parenthesize(string name, params Expression[] expressions)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("(").Append(name);
            foreach (Expression expression in expressions)
            {
                builder.Append(" ");
                builder.Append(expression.Accept(this));
            }
            builder.Append(")");

            return builder.ToString();
        }
    }
}
