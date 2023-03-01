using Domain.Entities;
using Domain.Enums;
using System;

namespace Domain.Business
{
    public static class ErrorHandling
    {
        public static void Error(int line, string message)
        {
            Report(line, "", message);
        }

        public static void Error(string message)
        {
            Report(message);
        }

        public static void Error(Token token, string message)
        {
            if (token.Type == TokenType.EOF)
            {
                Report(token.Line, " at end", message);
            }
            else
            {
                Report(token.Line, " at '" + token.Lexeme + "'", message);
            }
        }

        public static void RuntimeError(RuntimeError error)
        {
            Console.WriteLine(error.Message +
                "\n[line " + error.token.Line + "]");
        }

        private static void Report(int line, string where, string message)
        {
            Console.WriteLine($"[line {line}] Error {where}: {message}");
        }

        private static void Report(string message)
        {
            Console.WriteLine($"Error {message}");
        }
    }
}
