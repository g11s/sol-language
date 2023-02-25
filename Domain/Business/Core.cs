using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Business
{
    public class Core
    {
        public static void RunFile(string path)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(Path.GetFullPath(path));
                Run(Encoding.UTF8.GetString(bytes));
            }
            catch(Exception ex)
            {
                ErrorHandling.Error(ex.Message);
                Environment.Exit(65);
            }
        }

        public static void Run(string source)
        {
            Scanner scanner = new Scanner(source);
            List<Token> tokens = scanner.ScanTokens();

            foreach (Token token in tokens)
            {
                Console.WriteLine($"Type: {token.Type}, Lexeme: {token.Lexeme}, Line: {token.Line}, Literal: {token.Literal}");
            }
        }

        public static void RunPrompt()
        {
            while (true)
            {
                Console.WriteLine("> ");
                string line = Console.ReadLine();

                if (string.IsNullOrEmpty(line)) break;
                Run(line);
            }

            Console.WriteLine("Exiting prompt interactive...");
        }
    }
}
