using System;

namespace EventDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher m = new Publisher();
            Subscriber1 l = new Subscriber1();
            Subscriber2 l2 = new Subscriber2();
            l.Subscribe(m);
            l2.Subscribe2(m);

            m.Start();
        }
    }
}
