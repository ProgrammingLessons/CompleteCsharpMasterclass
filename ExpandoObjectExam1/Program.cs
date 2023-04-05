using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace ExpandoObjectExam1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic d = new ExpandoObject();
            IDictionary<string, object> members = d as IDictionary<string, object>;

            members.Add("Name", "Ekrem");
            members.Add("Job", "Developer");

            Console.WriteLine(d.Name);
            Console.WriteLine(d.Job);
            d.Event = null;
            d.Event += new EventHandler((sender, e) =>
            {
                Console.WriteLine("Event Invoke");
            });

            d.Event("", new EventArgs());
        }
    }
}
