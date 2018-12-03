using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class BrownBlock:Block
    {
        private Point destination;

        public Point Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        private void Initialize(Point d)
        {
            destination = d;
        }
        public BrownBlock():base()
        {
            Initialize(new Point(0, 0));
        }
        public BrownBlock(Point p) : base(p)
        {
            Initialize(new Point(0, 0));
        }
        public BrownBlock(Point p, Point d) : base(p)
        {
            Initialize(d);
        }

        public override void StopAction(Player player)
        {
            player.Location = Destination;
        }

    }
}
