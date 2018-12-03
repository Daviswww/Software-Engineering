using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class EventAddMoney2 : EventBase
    {
        public EventAddMoney2(int w) : base(w)
        {

        }
        public override void DoEvent(Player player)
        {
            MessageBox.Show("Add 10 dollars");
            player.Money += 10;
        }
    }
}
