using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class EventSubMoney : EventBase
    {
        public EventSubMoney(int w) : base(w)
        {

        }

        public override void DoEvent(Player player)
        {
            MessageBox.Show("Sub 3 dollars");
            player.Money -= 3;
        }
    }
}
