using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
    public class Subscriber2
    {
        public void Subscribe2(Publisher m)    
        {
            m.Tick += HeardIt;               
        }
        private void HeardIt(Publisher m, EventArgs e)   
        {
            System.Console.WriteLine("Subscribe2 listening");
        }
    }
}
