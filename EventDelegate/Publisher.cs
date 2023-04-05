using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
    public class Publisher
    {
        public delegate void TickHandler(Publisher m, EventArgs e); 
        public TickHandler Tick;     
        public EventArgs e = null;   
        public void Start()     
        {
            while (true)
            {
                System.Threading.Thread.Sleep(300);
                if (Tick != null)   
                {
                    Tick(this, e); 
                }
            }
        }
    }
}
