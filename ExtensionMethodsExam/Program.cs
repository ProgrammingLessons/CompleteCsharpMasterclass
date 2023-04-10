using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using static ExtensionMethodsExam.Extension;

namespace ExtensionMethodsExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(new Foo().Measure());
            // Object is defined
            var derived = new FooDevired();
            Foo parent = derived;
            // The length of the name variable in the object is learned
            Console.WriteLine("As parent:" + parent.Measure());
            Console.WriteLine("As child:" + derived.Measure());

            // The number 42 is converted to binary number system
            Console.WriteLine(42.ToBinary());

            // Person object is created
            var me = ("Ekrem", 29).ToPerson();
            Console.WriteLine(me);

            // In Tuple, the length of the second parameter is learned
            Console.WriteLine(Tuple.Create(1.0, false).Measure());

            // A function named calc is defined
            Func<int> calc = delegate
            {
                Thread.Sleep(1000);
                return 0;
            };
            // The calc method tells you how long it will take.
            var st = calc.Measure();
            Console.WriteLine("Stopwatch : " + st.ElapsedMilliseconds);

            // Date is created in datetime type
            var when = (2, 5, 2005).dmy();
            Console.WriteLine(when);

            // list1 and list2 lists are combined with the merge method.
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 4,5, 6 };
            var newList = (list1, list2).merge();

            // Adding label to test variable
            string test = "Exam variable";
            test.SetTag("ExampleTag1");
            Console.WriteLine(test.GetTag());
        }
    }
    // Extension methods must be defined as static methods under static class.
    public static class Extension
    {
        // Extension method that will work for the property of the Foo object.
        // Returns the length of the property.
        public static int Measure(this Foo foo)
        {
            return foo.Name.Length;
        }

        public static int Measure(this FooDevired foo)
        {
            return foo.Name.Length;
        }
        
        // A method that converts a decimal number to a binary number system.
        public static string ToBinary(this int n)
        {
            return Convert.ToString(n, 2);
        }
        
        // Creates a Person object with the value it takes with the parameter
        public static Person ToPerson(this (string name, int age) data)
        {
            return new Person { Name = data.name, Age = data.age };
        }
        
        // Returns the length of the second parameter in the tuple object.
        public static int Measure<T, U>(this Tuple<T, U> t)
        {
            return t.Item2.ToString().Length;
        }
        
        // It is learned how long a defined method will take.
        public static Stopwatch Measure(this Func<int> func)
        {
            var st = new Stopwatch();
            st.Start();
            func();
            st.Stop();
            return st;
        }
        
        // The parameter is created and returned with the values given.
        public static DateTime dmy(this (int day, int month, int year) when)
        {
            return new(when.year, when.month, when.day);
        }

        // Combines two lists of type T and returns a single list.
        public static List<T> merge<T>(this (IList<T> first, IList<T> second) lists)
        {
            var result = new List<T>();
            result.AddRange(lists.first);
            result.AddRange(lists.second);
            return result;
        }

        // method of adding tags to variables and seeing the attached tag
        private static Dictionary<WeakReference, object> data = new Dictionary<WeakReference, object>();
        public static object GetTag(this object o) 
        {
            var key = data.Keys.FirstOrDefault(x => x.IsAlive && x.Target == o);
            return key != null ? data[key] : null;
        }

        public static void SetTag(this object o, object tag)
        {
            var key = data.Keys.FirstOrDefault(x=>x.IsAlive && x.Target == o);
            if (key != null)
            {
                data[key] = tag;
            }
            else
            {
                data.Add(new WeakReference(o), tag);
            }
        }
    }

    public class Foo
    {
        public virtual string Name => "Foo";
    }

    public class FooDevired : Foo
    {
        public override string Name => "FooDevired";
    }

    public class Person
    {
        public string Name;
        public int Age;

        // The ToString method of the Person object is overridden
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Age)}:{Age}";
        }
    }


}
