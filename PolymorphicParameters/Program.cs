using System;
using System.Collections.Generic;

namespace PolymorphicParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            // Car list is created with Audi and BMW object
            var cars = new List<Car>
            {
                new Audi(200, "blue", "A6"),
                new BMW(300, "black", "X6")
            };

            foreach (var car in cars)
            {
                // will go to new method as it is overridden
                car.Repair();           
            }

            Car bmwZ3 = new BMW(200, "black", "Z3");
            Car audiA3 = new Audi(100, "green", "A3");
            // The method in the car class is called.
            bmwZ3.ShowDetails();
            audiA3.ShowDetails();

            BMW bmwM5 = new BMW(330, "white", "M5");
            bmwM5.ShowDetails();

            // We cast the bmwM5 object to the car class.
            Car carB = (Car)bmwM5;

            // Since you have cast, the method of the car class will be called.
            carB.ShowDetails();

            Console.ReadKey();
        }
    }
}
