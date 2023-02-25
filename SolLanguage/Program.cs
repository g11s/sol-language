using Domain.Business;
using System;

namespace SolLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
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
