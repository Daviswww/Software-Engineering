using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int step;
        private int step_count;
        private int current_player;
        private TurnPhase current_phase;
        private Player[] players;
        private Block[] map;
        private PictureBox[] players_image;
        private EventPool blue_event_pool, red_event_pool;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            step = 0;
            step_count = 0;
            current_player = 0;
            current_phase = TurnPhase.Begin;

            players = new Player[3];
            players[0] = new Lv1("Player 1", "player1.png");
            players[0].Location = new Point(0, 0);
            players[1] = new Lv2("Player 2", "player2.png");
            players[1].Location = new Point(0, 0);
            players[2] = new Lv3("Player 3", "player3.png");
            players[2].Location = new Point(0, 0);

            
            blue_event_pool = new EventPool();
            blue_event_pool.AddEvent(new EventAddMoney(5));
            blue_event_pool.AddEvent(new EventSubMoney(10));
            blue_event_pool.AddEvent(new EventNothing(15));

            red_event_pool = new EventPool();
            red_event_pool.AddEvent(new EventAddMoney(3));
            red_event_pool.AddEvent(new EventAddMoney1(6));
            red_event_pool.AddEvent(new EventAddMoney2(9));
            red_event_pool.AddEvent(new EventSubMoney(12));
            red_event_pool.AddEvent(new EventNothing(15));

            map = new Block[Constants.BlockNumber];
            map[0] = new GrayBlock(new Point(0, 0));
            map[1] = new BlueBlock(new Point(100, 0), blue_event_pool);
            map[2] = new RedBlock(new Point(200, 0), red_event_pool);
            map[3] = new BrownBlock(new Point(300, 0), new Point(0, 300));
            map[4] = new BlueBlock(new Point(300, 100), blue_event_pool);
            map[5] = new RedBlock(new Point(300, 200), red_event_pool);
            map[6] = new GreenBlock(new Point(300, 300));
            map[7] = new BlueBlock(new Point(200, 300), blue_event_pool);
            map[8] = new RedBlock(new Point(100, 300), red_event_pool);
            map[9] = new BrownBlock(new Point(0, 300), new Point(300, 0));
            map[10] = new BlueBlock(new Point(0, 200), blue_event_pool);
            map[11] = new RedBlock(new Point(0, 100), red_event_pool);

            pictureBox1.Load("map.png");
            players_image = new PictureBox[3];
            for(int i = 0;i < 3; i++)
            {
                players_image[i] = new PictureBox();
                players_image[i].SizeMode = PictureBoxSizeMode.StretchImage;
                players_image[i].Size = new Size(50, 50);
                players_image[i].Location =
                    new Point(players[current_player].Location.X + 25,
                              players[current_player].Location.Y + 25
                             );
                players_image[i].Image = players[i].Image;

                pictureBox1.Controls.Add(players_image[i]);
                players_image[i].BringToFront();
            }
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            step = 1;
            players[current_player].State = PlayerState.Walking;
            current_phase = TurnPhase.Walking;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            step = 2;
            players[current_player].State = PlayerState.Walking;
            current_phase = TurnPhase.Walking;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            step = 3;
            players[current_player].State = PlayerState.Walking;
            current_phase = TurnPhase.Walking;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            step = 4;
            players[current_player].State = PlayerState.Walking;
            current_phase = TurnPhase.Walking;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            current_player = (current_player + 1) % Constants.PlayerNumber;
            current_phase = TurnPhase.Begin;

            if (players[current_player].State == PlayerState.InJail)
            {
                current_phase = TurnPhase.Walking;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            switch(current_phase)
            {
                case TurnPhase.Begin:
                    break;
                case TurnPhase.Walking:
                    int now_index = players[current_player].BlockIndex;
                    int next_index = now_index;

                    if(players[current_player].State == PlayerState.Walking)
                    {
                        next_index = (now_index + 1) % Constants.BlockNumber;
                        if (step != 0)
                        {
                            players[current_player].Move(
                                    map[now_index].Location,
                                    map[next_index].Location,
                                    ++step_count);
                        }
                        if(step_count == Constants.StepTimes)
                        {
                            --step;
                            step_count = 0;
                            players[current_player].BlockIndex = next_index;
                            if(players[current_player].BlockIndex == 0 && step != 0)
                            {
                                //map[next_index].StopAction(players[current_player]);
                                players[current_player].PassiveSkill(map[next_index]);
                            }
                        }
                    }
                    if (step == 0)
                    {
                        timer1.Stop();

                        if (players[current_player].BlockIndex != 0)
                        {
                            // map[next_index].StopAction(players[current_player]);
                            players[current_player].PassiveSkill(map[next_index]);
                        }
                        current_phase = TurnPhase.End;

                        timer1.Start();
                    }
                    break;
                case TurnPhase.End:
                    break;
            }
            UpdateUI();
        }
        public void UpdateUI()
        {
            players_image[current_player].BringToFront();
            players_image[current_player].Location =
                new Point(players[current_player].Location.X + 25,
                          players[current_player].Location.Y + 25);
            label1.Text = players[current_player].Name;
            label2.Text = players[current_player].Money.ToString();
            label3.Text = players[current_player].State.ToString();
            label4.Text = step.ToString();

            switch(current_phase)
            {
                case TurnPhase.Begin:
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = false;
                    break;
                case TurnPhase.Walking:
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    break;
                case TurnPhase.End:
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = true;
                    break;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
