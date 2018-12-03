using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_2
{
    public partial class Form1 : Form
    {
        Smoke smoke;
        public Form1()
        {
            InitializeComponent();

            smoke = new Smoke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            smoke.FillParticle(10000);
            timer1.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            smoke.IsParallel = checkBox1.Checked;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int count = smoke.Particles.Count;
            for(int i = 0; i < count; ++i)
            {
                g.DrawEllipse(Pens.Orange, new Rectangle(smoke.Particles[i].Location, new Size(3, 3)));

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            smoke.Tick();
            pictureBox1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
