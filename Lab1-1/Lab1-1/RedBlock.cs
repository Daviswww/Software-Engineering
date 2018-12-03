using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_1
{
    class RedBlock : Block
    {
        public override int StopAction(int money)
        {
            return money -= (int)((money / 2.0f) + 0.5);
        }
    }
}
