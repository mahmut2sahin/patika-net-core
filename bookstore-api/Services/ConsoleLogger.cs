using System;

namespace bookstore_api.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}