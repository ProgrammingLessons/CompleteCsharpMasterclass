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
            // object is defined
            dynamic d = new ExpandoObject();
            // A dictionary definition is made to keep the properties.
            IDictionary<string, object> members = d as IDictionary<string, object>;
            // Two properties named Name and Job are added.
            members.Add("Name", "Ekrem");
            members.Add("Job", "Developer");

            Console.WriteLine(d.Name);
            Console.WriteLine(d.Job);
            d.Event = null;
            // Event is defined
            d.Event += new EventHandler((sender, e) =>
            {
                Console.WriteLine("Event Invoke");
            });
            // Event is triggered
            d.Event("", new EventArgs());
        }
    }
}
