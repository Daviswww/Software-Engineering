using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class RedBlock : Block
    {
        private EventPool events;

        public EventPool Events
        {
            get { return events; }
            set { events = value; }
        }
        public RedBlock() : base()
        {
            Initialize(new EventPool());
        }
        public RedBlock(Point p) : base(p)
        {
            Initialize(new EventPool());
        }
        public RedBlock(Point p, EventPool ep) : base(p)
        {
            Initialize(ep);
        }
        public void Initialize(EventPool ep)
        {
            events = ep;
        }
        public override void StopAction(Player player)
        {
            Events.GetEvent().DoEvent(player);
        }
    }
}
