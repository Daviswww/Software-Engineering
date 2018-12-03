using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class GrayBlock:Block
    {
        
        public GrayBlock() : base()
        {

        }
        public GrayBlock(Point p) : base(p)
        {

        }
        public override void StopAction(Player player)
        {
         player.Money += 50 ;
        }
    }
}
