using Domain.Business;
using Domain.Entities;
using Domain.Enums;
using Domain.Tools;
using System;

namespace SolLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            //Expression expression = new Binary(
            //    new Unary(
            //        new Token(TokenType.MINUS, "-", null, 1),
            //        new Literal(123)
            //    ),
            //    new Token(TokenType.STAR, "*", null, 1),
            //    new Grouping(
            //        new Literal(45.67)
            //    )
            //);

            //Console.WriteLine(new AstPrinter().Print(expression));

            if (args.Length > 1)
            {
                Console.WriteLine("Usage: Sol [script]");
                Environment.Exit(64);
            } 
            else if (args.Length == 1)
            {
                Core.RunFile(args[0]);
            } 
            else
            {
                Core.RunPrompt();
            }
        }
    }
}
