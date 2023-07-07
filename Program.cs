using System;
using System.IO;
using ATM_Machine.db;

namespace ATM_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var db = new DBConnector();
            Console.WriteLine(db);
        }
    }
}
