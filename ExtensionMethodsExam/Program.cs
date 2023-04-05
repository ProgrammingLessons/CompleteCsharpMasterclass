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
            //Console.WriteLine(new Foo().Measure());

            var derived = new FooDevired();
            Foo parent = derived;
            Console.WriteLine("As parent:" + parent.Measure());
            Console.WriteLine("As child:" + derived.Measure());

            Console.WriteLine(42.ToBinary());

            var me = ("Ekrem", 29).ToPerson();
            Console.WriteLine(me);

            Console.WriteLine(Tuple.Create(1.0, false).Measure());

            Func<int> calc = delegate
            {
                Thread.Sleep(1000);
                return 0;
            };

            var st = calc.Measure();
            Console.WriteLine("Stopwatch : " + st.ElapsedMilliseconds);

            var when = (2, 5, 2005).dmy();
            Console.WriteLine(when);


            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 4,5, 6 };
            var newList = (list1, list2).merge();

            string test = "Exam variable";
            test.SetTag("ExampleTag1");
            Console.WriteLine(test.GetTag());
        }
    }

    public static class Extension
    {
        public static int Measure(this Foo foo)
        {
            return foo.Name.Length;
        }

        public static int Measure(this FooDevired foo)
        {
            return foo.Name.Length;
        }

        public static string ToBinary(this int n)
        {
            return Convert.ToString(n, 2);
        }

        public static Person ToPerson(this (string name, int age) data)
        {
            return new Person { Name = data.name, Age = data.age };
        }

        public static int Measure<T, U>(this Tuple<T, U> t)
        {
            return t.Item2.ToString().Length;
        }

        public static Stopwatch Measure(this Func<int> func)
        {
            var st = new Stopwatch();
            st.Start();
            func();
            st.Stop();
            return st;
        }

        public static DateTime dmy(this (int day, int month, int year) when)
        {
            return new(when.year, when.month, when.day);
        }

        public static List<T> merge<T>(this (IList<T> first, IList<T> second) lists)
        {
            var result = new List<T>();
            result.AddRange(lists.first);
            result.AddRange(lists.second);
            return result;
        }


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

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, " +
                       $"{nameof(Age)}:{Age}";
            }
        }


}
