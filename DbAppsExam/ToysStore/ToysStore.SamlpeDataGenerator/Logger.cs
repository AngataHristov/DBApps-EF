namespace ToysStore.SamlpeDataGenerator
{
    using System;

    using Interfaces;

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.Write(message);
        }

        public void LogLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
