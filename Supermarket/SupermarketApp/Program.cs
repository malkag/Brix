using System;
using SupermarketLib;

namespace CashiersQueueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();
            supermarket.Start();
            Console.ReadLine();
        }
    }
}
