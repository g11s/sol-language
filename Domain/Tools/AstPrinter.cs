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

        public string visit(Binary binary)
        {
            return parenthesize(binary.op.Lexeme,
                                binary.left, binary.right);
        }

        public string visit(Grouping grouping)
        {
            return parenthesize("group", grouping.expression);
        }

        public string visit(Literal literal)
        {
            if (literal.value == null) return "nil";
            return literal.value.ToString();
        }

        public string visit(Unary unary)
        {
            return parenthesize(unary.op.Lexeme, unary.right);
        }

        private string parenthesize(string name, params Expression[] expressions)
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
