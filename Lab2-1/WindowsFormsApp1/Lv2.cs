using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Lv2 : Player
    {
        public Lv2(string p_name, string path) : base(p_name, path)
        {

        }
        public override void PassiveSkill(Block block)
        {
            int k = Money;
            block.StopAction(this);
            Money += (Money - k);
        }
    }
}
