using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class EventAddMoney : EventBase
    {
        public EventAddMoney(int w) : base(w)
        {

        }

        public override void DoEvent(Player player)
        {
            MessageBox.Show("Add 5 dollars");
            player.Money += 5;
        }
    }
}
