using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    class Player
    {
        public Point Location;
        public MoveAnimation[] MoveAnima;
        public List<Direction> Directions;
        public double MoveSpeed;

        public Player()
        {
            Location = new Point(0, 0);
            MoveAnima = new MoveAnimation[4];
            //Direction = Direction.Up;
            Directions = new List<Direction>();
        }
        public void SetDirections(Direction D)
        {
            if(!Directions.Contains(D) && Directions.Count < 2)
            {
                Directions.Add(D);
            }
        }

        public void RemoveDirections(Direction D)
        {
            Directions.Remove(D);
        }
        public void Move(double time)
        {
            foreach(Direction D in Directions)
            {
                double dx = time * MoveSpeed * (D == Direction.Left ? -1 : (D == Direction.Right ? 1 : 0));
                double dy = time * MoveSpeed * (D == Direction.Up ? -1 : (D == Direction.Down ? 1 : 0));
                if (Location.X + (int)dx > 450 || Location.X + (int)dx < 0)
                {
                    dx = 0;
                }
                if(Location.Y + (int)dy  > 430 || Location.Y + (int)dy < 0)
                {
                    dy = 0;
                }
                Location = new Point(Location.X  + (int)dx, Location.Y + (int)dy );
            }
        }
        public void Draw(PaintEventArgs e)
        {
            if(Directions.Count == 0)
            {
                MoveAnima[(int)Direction.Up].Draw(e);
            }
            else
            {
                MoveAnima[(int)Directions[0]].Draw(e);
            }
        }
    }
}
