using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class GreenBlock : Block
    {
        public GreenBlock():base()
        {

        }
        public GreenBlock(Point p):base(p)
        {

        }
        public override void StopAction(Player player)
        {
            if(player.State == PlayerState.InJail)
            {
                --player.JailTurns;
                if(player.JailTurns == 0)
                {
                    player.State = PlayerState.Normal;
                }

            }
            else
            {
                player.JailTurns = 1;
                player.State = PlayerState.InJail;
            }
        }

    }
}
