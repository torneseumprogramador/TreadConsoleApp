using System;
using System.Threading;

namespace TreadConsoleApp
{
    class Program
    {
        static async void Main(string[] args)
        {
            Thread t = new Thread(Print);
            t.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.Write(0);
            }
        }

        private static void Print()
        {
            for(int i=0; i < 1000; i++)
            {
                Console.Write(1);
            }
        }
    }
}
