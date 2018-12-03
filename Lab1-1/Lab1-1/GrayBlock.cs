using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_1
{
    class GrayBlock : Block
    {
        public override int StopAction(int money)
        {
            return money += 50;
        }
    }
}
