using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
    public class Subscriber1
    {
        public void Subscribe(Publisher m)  
        {
            m.Tick += HeardIt;              
        }
        private void HeardIt(Publisher m, EventArgs e)   
        {
            System.Console.WriteLine("Subscribe1 listening");
        }
    }
}
