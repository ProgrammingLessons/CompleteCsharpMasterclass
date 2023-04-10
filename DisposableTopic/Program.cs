using System;
using System.Diagnostics;
using System.Threading;

namespace DisposableTopic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Using using ensures that the Dispose method is called when the scope ends.
            using (new MyClass()) { }

            using (new SimpleTimer())
            {
                Thread.Sleep(1000);
            }
        }
    }

    public class MyClass : IDisposable
    {
        public MyClass() {
            Console.WriteLine("Class creted");
        }

        // The object is removed from memory with the Dispose method. 
        public void Dispose()
        {
            Console.WriteLine("Bye");
        }
    }

    public class SimpleTimer : IDisposable
    {
        private readonly Stopwatch st;
        public SimpleTimer()
        {
            st = new Stopwatch();
            st.Start();
        }

        public void Dispose()
        {
            st.Stop();
            Console.WriteLine($"{st.ElapsedMilliseconds} msec elapsed");
        }
    }
}
