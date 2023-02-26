using Domain.Entities;

namespace Domain.Interfaces.Business
{
    public interface ExpressionVisitor
    {
        string visit(Literal literal);
        string visit(Unary unary);
        string visit(Grouping grouping);
        string visit(Binary binary);
    }
}
