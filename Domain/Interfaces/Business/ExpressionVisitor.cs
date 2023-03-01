using Domain.Entities;

namespace Domain.Interfaces.Business
{
    public interface ExpressionVisitor
    {
        dynamic Visit(Literal literal);
        dynamic Visit(Unary unary);
        dynamic Visit(Grouping grouping);
        dynamic Visit(Binary binary);
    }
}
