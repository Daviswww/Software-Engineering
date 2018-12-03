using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Player
    {
        private string name;
        private int block_index;
        private int money;
        private Point location;
        private PlayerState state;
        private Bitmap image;
        private int jail_turns;

        public int JailTurns
        {
            get { return jail_turns; }
            set { jail_turns = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int BlockIndex
        {
            get { return block_index; }
            set { block_index = value; }
        }
        public int Money
        {
            get { return money; }
            set { money = value; }
        }
        public Point Location
        {
            get { return location; }
            set { location = value; }
        }
        public PlayerState State
        {
            get { return state; }
            set { state = value; }
        }
        public Bitmap Image
        {
            get { return image; }
        }
        public Player()
        {
            Initialize();
        }
        public Player(string p_name, string path)
        {
            Initialize(p_name, path);
        }
        private void Initialize(string p_name = "", string path = "")
        {
            Name = p_name;
            BlockIndex = 0;
            Money = 0;
            Location = new Point(0, 0);
            State = PlayerState.Normal;
            image = null;
            if(path != "")
            {
                image = new Bitmap(path);
            }
        }
        public void Move(Point now, Point next, int n)
        {
            int x = (next.X - now.X) * n / 10;
            int y = (next.Y - now.Y) * n / 10;
            Location = new Point(now.X + x, now.Y + y);
        }

        public virtual void PassiveSkill(Block block)
        {

        }
    }
}
