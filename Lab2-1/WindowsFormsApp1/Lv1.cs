using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Lv1 : Player
    {
        public Lv1(string p_name, string path) : base(p_name , path)
        {

        }
        public override void PassiveSkill(Block block)
        {
            if (!(block is GreenBlock))
            {
                block.StopAction(this);
            }
        }
    }
}
