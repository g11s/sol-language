using Domain.Entities;
using System;

namespace Domain.Business
{
    public class RuntimeError : Exception
    {
        public Token token;

        public RuntimeError(Token token, string message) : base(message)
        {
            this.token = token;
        }
    }
}
