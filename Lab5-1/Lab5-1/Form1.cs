using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_1
{
    public partial class Form1 : Form
    {

        int counter;
        int state;
        int limit;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = counter.ToString();

            if (state == 0)
            {
                state = 1;
                BackgroundWorker worker1 = new BackgroundWorker();
                worker1.DoWork += Worker1_DoWork;
                worker1.RunWorkerCompleted += Worker1_RunWorkerCompleted;
                worker1.RunWorkerAsync();
            }
            else if (state == 2)
            {
                state = 3;
                BackgroundWorker worker2 = new BackgroundWorker();
                worker2.DoWork += Worker2_DoWork;
                worker2.RunWorkerCompleted += Worker2_RunWorkerCompleted;
                worker2.RunWorkerAsync();
            }
        }
        private void Worker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            state = 2;
        }
        private void Worker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            state = 2;
        }
        private void Worker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(counter < limit)
            {
                ++counter;
                Thread.Sleep(1);
            }
        }
        private void Worker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (counter > 0)
            {
                --counter;
                Thread.Sleep(1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter = 0;
            state = 0;
            limit = 5000;
            timer1.Start();
        }
    }
}
