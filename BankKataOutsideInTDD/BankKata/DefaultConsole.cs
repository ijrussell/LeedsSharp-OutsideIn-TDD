using System;

namespace BankKata
{
    public class DefaultConsole : IConsole
    {
        public void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}