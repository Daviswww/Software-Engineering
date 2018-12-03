using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_1
{
    class BrownBlock : Block
    {
        private Random rand;
        public BrownBlock()
        {
            rand = new Random();
        }
        public override int StopAction(int money)
        {
            int r = rand.Next(14) - 5;

            if(money + r < 0)
            {
                money = 0;
                return money;
            }
            else
            {
                return money += r;
            }
            
        }
    }
}
