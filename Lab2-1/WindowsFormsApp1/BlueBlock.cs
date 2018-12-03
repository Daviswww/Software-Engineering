using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class BlueBlock : Block
    {
        private EventPool events;

        public EventPool Events
        {
            get { return events; }
            set { events = value; }
        }
        public BlueBlock():base()
        {
            Initialize(new EventPool());
        }
        public BlueBlock(Point p) : base(p)
        {
            Initialize(new EventPool());
        }
        public BlueBlock(Point p, EventPool ep) : base(p)
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
