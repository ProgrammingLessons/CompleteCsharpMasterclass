using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicParameters
{
    public class Car
    {
        public Car(int hP, string color)
        {
            HP = hP;
            Color = color;
        }

        public int HP { get; set; }
        public string Color { get; set; }

        public new void ShowDetails()
        {
            Console.WriteLine("HP: " + HP + " color:" + Color);
        }

        public virtual void Repair()
        {
            Console.WriteLine("Car was repaired");
        }

    }
}
