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
