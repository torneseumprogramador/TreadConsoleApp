using System;
using System.Threading;

namespace TreadConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintThreadExemple();
            // ThreadSpeep();

            MultipleThread();
        }

        private static void PrintThreadExemple()
        {
            //Print();

            // passo 1
            // Print();
            Thread t = new Thread(Print);
            t.Start();

            // passo 2
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

        private static void ThreadSpeep()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }

        private static void MultipleThread()
        {
            Thread[] threads = new Thread[15];

            Thread.CurrentThread.Name = "Principal";

            for (int i = 0; i < 15; i++)
            {
                PagGatway pag = new PagGatway();
                pag.ClientName = "Danilo " + i;
                pag.Value = i * 15;
                Thread t = new Thread(new ThreadStart(pag.Pay));
                t.Name = i.ToString();
                threads[i] = t;
            }

            //threads[1].Priority = ThreadPriority.Highest;
            threads[1].Priority = ThreadPriority.Highest;

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("Thread {0} Alive : {1}", threads[i].Name, threads[i].IsAlive);

                threads[i].Start();

                Console.WriteLine("Thread {0} Alive : {1}", threads[i].Name, threads[i].IsAlive);
            }

            Console.WriteLine("Current Priority : {0}", Thread.CurrentThread.Priority);

            Console.WriteLine("Thread {0} Ending", Thread.CurrentThread.Name);

            Console.ReadLine();
        }
    }


    class PagGatway
    {
        public string ClientName { get; set; }
        public double Value { get; set; }

        public void Pay()
        {
            Pay(1000);
        }

        public void Pay(int sleepTime)
        {
            Thread.Sleep(sleepTime);
            Console.WriteLine($"Pagamento do {this.ClientName} efetuado com sucesso, no valor {this.Value}");
        }
    }
}
