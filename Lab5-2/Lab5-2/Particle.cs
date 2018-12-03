using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_2
{
    class Particle
    {
        public Point Location { get; set; }
        public Point V { get; set; }
        public int Life { get; set; }
        public static Random rand = new Random();

        public Particle()
        {
            Location = new Point();
        }

        public void Move(int n)
        {
            Location = new Point(Location.X + V.X, Location.Y + V.Y);
            --Life;

            while(n > 0)
            {
                --n;
            }
        }
        public static Particle GetNewParticle()
        {
            Particle p = new Particle();
            p.Location = new Point(rand.Next(100)+100, 300);
            p.V = new Point(rand.Next(5)-2, -(rand.Next(10) + 1));
            p.Life = rand.Next(40);

            return p;
        }
    }
}
