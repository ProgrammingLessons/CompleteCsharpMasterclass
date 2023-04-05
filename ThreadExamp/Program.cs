using System;
using System.Threading;

namespace ThreadExamp
{
    internal class Program
    {
        private static EventWaitHandle onReadyEvenThread;
        private static EventWaitHandle onReadyOddThread;
        static void Main(string[] args)
        {
            onReadyOddThread = new AutoResetEvent(true);
            onReadyEvenThread = new AutoResetEvent(false);

            Thread threadOne = new Thread(oddNumbers);
            Thread threadTwo = new Thread(evenNumbers);

            threadOne.Start();
            threadTwo.Start();

            threadOne.Join();
            threadTwo.Join();
        }

        public static void oddNumbers()
        {
            for (int i = 1; i < 100; i += 2)
            {
                onReadyEvenThread.WaitOne();
                Console.WriteLine("thread " + 1 + ": The number is '" + i + "'");
                onReadyOddThread.Set();
            }
        }

        public static void evenNumbers()
        {
            for (int i = 0; i <= 100; i += 2)
            {
                onReadyOddThread.WaitOne();
                if (i > 0)
                    Console.WriteLine("thread " + 2 + ": The number is '" + i + "'");
                onReadyEvenThread.Set();
            }
        }
    }
}
