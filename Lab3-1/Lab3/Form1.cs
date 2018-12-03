using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private Player player;
        private bool is_dir_down;
        private DateTime time;
        private bool[] keys;
        private ClickPower power;
        private bool is_mouse_down;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            power = new ClickPower();
            power.ChargeTime = 3;
            is_mouse_down = false;

            is_dir_down = false;
            keys = new bool[4];
            for(int i = 0; i <4; ++i)
            {
                keys[i] = false;
            
            }
            pictureBox1.Image = new Bitmap("map.png");
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;

            player = new Player();
            player.MoveSpeed = 100;

            Bitmap bmp = new Bitmap("charall.png");
            MoveAnimation move = new MoveAnimation();
            move.Duration = 1.0;
            move.Frames.Add(new SingleFrame(bmp, new Point(0, 0), new Size(49, 65)));
            move.Frames.Add(new SingleFrame(bmp, new Point(48, 0), new Size(49, 65)));
            move.Frames.Add(new SingleFrame(bmp, new Point(97, 0), new Size(49, 65)));
            player.MoveAnima[0] = move;
            move = new MoveAnimation();
            move.Duration = 1.0;
            move.Frames.Add(new SingleFrame(bmp, new Point(0, 71), new Size(49, 65)));
            move.Frames.Add(new SingleFrame(bmp, new Point(48, 71), new Size(49, 65)));
            move.Frames.Add(new SingleFrame(bmp, new Point(97, 71), new Size(49, 65)));
            player.MoveAnima[1] = move;
            move = new MoveAnimation();
            move.Duration = 1.0;
            move.Frames.Add(new SingleFrame(bmp, new Point(0, 135), new Size(49, 65)));
            move.Frames.Add(new SingleFrame(bmp, new Point(48, 135), new Size(49, 65)));
            move.Frames.Add(new SingleFrame(bmp, new Point(97, 135), new Size(49, 65)));
            player.MoveAnima[2] = move;
            move = new MoveAnimation();
            move.Duration = 1.0;
            move.Frames.Add(new SingleFrame(bmp, new Point(0, 199), new Size(49, 65)));
            move.Frames.Add(new SingleFrame(bmp, new Point(49, 199), new Size(49, 65)));
            move.Frames.Add(new SingleFrame(bmp, new Point(99, 199), new Size(49, 65)));
            player.MoveAnima[3] = move;

            time = DateTime.Now;
            timer1.Start();

            pictureBox2.Paint += PictureBox_Char_Paint;
        }
        private void PictureBox_Char_Paint(object sender, PaintEventArgs e)
        {
            player.Draw(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(is_dir_down)
            {
                player.Move(timer1.Interval / 1000.0);
                pictureBox2.Location = player.Location;
                pictureBox2.Refresh();
            }
            if(is_mouse_down)
            {
                progressBar1.Value = power.GetPower();
                label1.Text = progressBar1.Value.ToString();
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(!is_mouse_down)
            {
                power.Srart();
                is_mouse_down = true;

            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (is_mouse_down)
            {
                is_mouse_down = false;

            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        { 
            if(e.KeyCode == Keys.Up && !keys[0])
            {
                player.SetDirections(Direction.Up);
                player.MoveAnima[0].Strat();
                keys[0] = true;
            }
            if (e.KeyCode == Keys.Right && !keys[1])
            {
                player.SetDirections(Direction.Right);
                player.MoveAnima[1].Strat();
                keys[1] = true;
            }
            if (e.KeyCode == Keys.Down && !keys[2])
            {
                player.SetDirections(Direction.Down);
                player.MoveAnima[2].Strat();
                keys[2] = true;
            }
            if (e.KeyCode == Keys.Left && !keys[3])
            {
                player.SetDirections(Direction.Left);
                player.MoveAnima[3].Strat();
                keys[3] = true;
            }
            is_dir_down = false;
            foreach(bool k in keys)
            {
                is_dir_down |= k;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && keys[0])
            {
                keys[0] = false;
                player.RemoveDirections(Direction.Up);
            }
            if (e.KeyCode == Keys.Right && keys[1])
            {
                keys[1] = false;
                player.RemoveDirections(Direction.Right);
            }
            if (e.KeyCode == Keys.Down && keys[2])
            {
                keys[2] = false;
                player.RemoveDirections(Direction.Down);
            }
            if (e.KeyCode == Keys.Left && keys[3])
            {
                keys[3] = false;
                player.RemoveDirections(Direction.Left);
            }
            is_dir_down = false;
            foreach (bool k in keys)
            {
                is_dir_down |= k;
            }
        }
    }
}
