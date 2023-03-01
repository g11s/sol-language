using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Business;
using System;

namespace Domain.Business
{
    public class Interpreter : ExpressionVisitor
    {
        public void Interpret(Expression expression)
        {
            try
            {
                dynamic value = Evaluate(expression);
                Console.WriteLine(Stringify(value));
            }
            catch (RuntimeError error)
            {
                ErrorHandling.RuntimeError(error);
            }
        }

        private string Stringify(dynamic param)
        {
            if (param == null) return "nil";

            if (param is double) {
                string text = param.ToString();
                if (text.EndsWith(".0"))
                {
                    text = text.Substring(0, text.Length - 2);
                }
                return text;
            }

            return param.ToString();
        }

        public dynamic Visit(Literal literal)
        {
            return literal.value;
        }

        public dynamic Visit(Unary unary)
        {
            dynamic right = Evaluate(unary.right);

            switch (unary.op.Type) {
                case TokenType.BANG:
                    return !IsTruthy(right);
                case TokenType.MINUS:
                    return -(double)right;
            }

            return null;
        }

        public dynamic Visit(Grouping grouping)
        {
            return Evaluate(grouping.expression);
        }

        public dynamic Visit(Binary binary)
        {
            dynamic left = Evaluate(binary.left);
            dynamic right = Evaluate(binary.right);

            switch (binary.op.Type) {
                case TokenType.GREATER:
                    return (double)left > (double)right;
                case TokenType.GREATER_EQUAL:
                    return (double)left >= (double)right;
                case TokenType.LESS:
                    return (double)left < (double)right;
                case TokenType.LESS_EQUAL:
                    return (double)left <= (double)right;
                case TokenType.MINUS:
                    return (double)left - (double)right;
                case TokenType.PLUS:
                    if (left is double && right is double) {
                        return (double)left + (double)right;
                    }

                    if (left is string && right is string) {
                        return (string)left + (string)right;
                    }

                    break;
                case TokenType.SLASH:
                    return (double)left / (double)right;
                case TokenType.STAR:
                    return (double)left * (double)right;
                case TokenType.BANG_EQUAL: 
                    return !IsEqual(left, right);
                case TokenType.EQUAL_EQUAL: 
                    return IsEqual(left, right);
            }

            return null;
        }

        private dynamic Evaluate(Expression expression)
        {
            return expression.Accept(this);
        }

        private bool IsTruthy(dynamic param)
        {
            if (param == null) return false;
            if (param is bool) return (bool)param;
            return true;
        }

        private bool IsEqual(dynamic a, dynamic b)
        {
            if (a == null && b == null) return true;
            if (a == null) return false;

            return a.equals(b);
        }
    }
}
