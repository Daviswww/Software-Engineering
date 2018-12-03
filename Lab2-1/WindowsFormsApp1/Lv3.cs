using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Lv3 : Player
    {
        public Lv3(string p_name, string path) : base(p_name, path)
        {

        }
        public override void PassiveSkill(Block block)
        {
            block.StopAction(this);
        }
    }
}
