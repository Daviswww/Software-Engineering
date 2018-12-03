using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Block
    {
        private Point location;
        public Point Location
        {
            get { return location; }
            set { location = value; }
        }
        private void Initialize(Point p)
        {
            location = p;
        }
        public Block()
        {
            Initialize(new Point(0, 0));
        }
        public Block(Point p)
        {
            Initialize(p);
        }
        public virtual void StopAction(Player player)
        {
            ++player.Money;
            player.State = PlayerState.Stop;
        }
    }
}
