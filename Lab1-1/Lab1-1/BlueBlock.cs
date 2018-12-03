using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_1
{
    class BlueBlock : Block
    {
        private int num;
        public BlueBlock()
        {
            num = 0;
        }
        public override int StopAction(int money)
        {
            num++;
            return money += num;
        }
    }
}
