using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class EventAddMoney1 : EventBase
    {
        public EventAddMoney1(int w) : base(w)
        {

        }

        public override void DoEvent(Player player)
        {
            MessageBox.Show("Add 7 dollars");
            player.Money += 7;
        }
    }
}
