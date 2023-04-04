using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicParameters
{
    public class Audi : Car
    {
        private string brand = "Audi";
        public string Model { get; set; }
        public Audi(int hP, string color, string model) : base(hP, color)
        {
            Model = model;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Brand " + brand + " HP: " + HP + " color:" + Color);
        }

        public override void Repair()
        {
            Console.WriteLine("The Audi {0} was repaired", Model);
        }
    }
}
