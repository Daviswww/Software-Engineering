using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract class EventBase
    {
        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public EventBase(int w = 1)
        {
            Weight = w;
        }
        public abstract void DoEvent(Player player);
    }
}
