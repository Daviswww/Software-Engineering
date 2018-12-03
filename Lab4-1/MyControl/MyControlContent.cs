using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyControl
{
    class MyControlContent
    {
        public MyModule.CalculateModule my_module;
        public MyView.Form1 my_view;
        
        public MyControlContent()
        {
            my_module = new MyModule.CalculateModule();
            my_view = new MyView.Form1();

            my_view.T1Cganged += TAChanged;
            my_view.T2Cganged += TBChanged;
            my_view.OpClick += OpClick;
        }

        public void TAChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            //MessageBox.Show("A");
            my_module.A = Convert.ToInt32(box.Text);
        }
        public void TBChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            //MessageBox.Show("B");
            my_module.B = Convert.ToInt32(box.Text);
        }
        public void OpClick(string op)
        {
            //MessageBox.Show(op);
            my_view.SetResult(my_module.Calcukate(op).ToString());
        }
    }
}
