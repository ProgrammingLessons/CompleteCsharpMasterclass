using System;
using System.Diagnostics;
using System.Linq;

namespace MemoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region In Parameter
            Product product = new Product();
            InModify(in product);
            #endregion

            #region Ref Parameters
            Product refProduct = new Product();
            RefModify(ref refProduct);

            int number = 5;
            Increment(ref number);
            Console.WriteLine("Number : " + number);
            #endregion

            #region Out Parameters
            int x;
            SetNumber(out x);
            #endregion

            #region Benchmark
            //Comparing what the ref and in parameter will notice in 100000000 cycles.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BenchmarkIncrementByRef(1000000000);
            stopwatch.Stop();
            Console.WriteLine($"Ref Parameter : { stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Restart();
            stopwatch.Start();
            BenchmarkIncrementByIn(1000000000);
            stopwatch.Stop();
            Console.WriteLine($"In Parameter : {stopwatch.ElapsedMilliseconds}ms");
            #endregion


            #region ReadOnlySpan, Span, Memory, Stackalloc
            //We cannot change the value in the relevant index in ReadOnlySpan.

            string plate = "EKREMISCAN1993";
            ReadOnlySpan<char> s = plate.AsSpan();
            s = s.Slice(10); // extract first 10 characters

            int year = int.Parse(s);
            Console.WriteLine($"Year : {year}");

            //////////////////////////////////////////////////////////////////////////////
            int[] LostNumbers = { 4, 8, 15, 16, 23, 42 };
            Span<int> span = LostNumbers;
            Span<int> span2 = LostNumbers.AsSpan(2, 3); //index start 2 select count 3 item
            span.ToArray().ToList().ForEach(i => Console.Write(i + ","));
            Console.WriteLine("");
            Console.Write(string.Concat(Enumerable.Repeat("*", 80)));
            Console.WriteLine("");
            span2.ToArray().ToList().ForEach(i => Console.Write(i + ","));
            ///////////////////////////////////////////////////////////////////////////////

            // Using Span with Stackalloc
            int length = 3;
            Span<int> numbers = stackalloc int[length];
            for (var i = 0; i < length; i++)
            {
                numbers[i] = i;
            }

            #endregion
        }

        #region Using Ref, In, Out Paramters 
        //It is stated that it will use the same reference as the In parameter.
        public static void InModify(in Product product)
        {
            // With in assigning a new object would throw an error
            //product = new Product();  
            product.ProductId = 101;
            product.ProductName = "Laptop";
            product.Price = 60000;
            Console.WriteLine($"Id: {product.ProductId} Name: {product.ProductName} Price: {product.Price}");
        }

        public static void RefModify(ref Product product)
        {
            //If a new object is created by giving the object's reference to the method,
            //there will be no change because it looks at the same reference.
            product.ProductId = 205;
            product.ProductName = "Camera";
            product.Price = 4500;
            product = new Product();
            product.ProductId = 300;
            product.ProductName = "Screen";
            product.Price = 3658;

        }

        public static void Increment(ref int num)
        {
            num = num + 1;
        }

        public static void SetNumber(out int num)
        {
            num = 25;
        }
        #endregion

        public static void BenchmarkIncrementByRef(int limit)
        {
            SixteenBitStruct sixteenBitStruct = new SixteenBitStruct();
            int counter = 0;
            do
            {
                IncrementByRef(ref sixteenBitStruct);
                counter++;
            }
            while (limit != counter);
        }

        public static void BenchmarkIncrementByIn(int limit)
        {
            SixteenBitStruct sixteenBitStruct = new SixteenBitStruct();
            int counter = 0;
            do
            {
                IncrementIn(sixteenBitStruct);
                counter++;
            }
            while (limit != counter);
        }

        private static void IncrementByRef(ref SixteenBitStruct sixteenBitStruct)
        {
            double sum = sixteenBitStruct.D1 + sixteenBitStruct.D2;
        }

        private static void IncrementIn(in SixteenBitStruct sixteenBitStruct)
        {
            double sum2 = sixteenBitStruct.D1 + sixteenBitStruct.D2;
        }
    }

    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }

    public struct SixteenBitStruct
    {
        public double D1 { get; }
        public double D2 { get; }
    }

    
}
