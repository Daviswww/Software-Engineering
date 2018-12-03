using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_1
{
    public partial class Form1 : Form
    {
        private int now_loc;
        private int step;
        private int money;
        private Block[] map;
        private Random rand;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Load("map.png");
            pictureBox2.Load("player.bmp");
            pictureBox2.Location = new Point(pictureBox1.Location.X + 25, pictureBox1.Location.Y + 25);

            rand = new Random();

            now_loc = 0;
            step = 0;
            money = 0;
            map = new Block[12];
            map[0] = new GrayBlock();
            map[0].Location = new Point(0, 0);
            map[1] = new BlueBlock();
            map[1].Location = new Point(100, 0);
            map[2] = new RedBlock();
            map[2].Location = new Point(200, 0);
            map[3] = new BrownBlock();
            map[3].Location = new Point(300, 0);
            map[4] = new BlueBlock();
            map[4].Location = new Point(300, 100);
            map[5] = new RedBlock();
            map[5].Location = new Point(300, 200);
            map[6] = new BrownBlock();
            map[6].Location = new Point(300, 300);
            map[7] = new BlueBlock();
            map[7].Location = new Point(200, 300);
            map[8] = new RedBlock();
            map[8].Location = new Point(100, 300);
            map[9] = new BrownBlock();
            map[9].Location = new Point(0, 300);
            map[10] = new BlueBlock();
            map[10].Location = new Point(0, 200);
            map[11] = new RedBlock();
            map[11].Location = new Point(0, 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = rand.Next(3) + 1;
            label1.Text = r.ToString();
            step = r;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (step != 0)
            {
                int next_loc = (now_loc + 1) % 12;
                Point dis = new Point((map[next_loc].Location.X - map[now_loc].Location.X) / 10,
                                      (map[next_loc].Location.Y - map[now_loc].Location.Y) / 10);
                pictureBox2.Location = new Point(pictureBox2.Location.X + dis.X, pictureBox2.Location.Y + dis.Y);
                if (pictureBox2.Location.X - pictureBox1.Location.X == map[next_loc].Location.X + 25 &&
                   pictureBox2.Location.Y - pictureBox1.Location.Y == map[next_loc].Location.Y + 25)
                {
                    --step;
                    now_loc = next_loc;
                }
                if (step == 0)
                {
                    money = map[now_loc].StopAction(money);
                    label2.Text = money.ToString();
                }
            }
        }
    }
}
