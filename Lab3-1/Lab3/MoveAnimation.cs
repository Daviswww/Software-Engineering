using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    class MoveAnimation
    {
        private DateTime star_time;

        public List<SingleFrame> Frames;
        public double Duration;

        public MoveAnimation()
        {
            Frames = new List<SingleFrame>();
            star_time = new DateTime();
            star_time = DateTime.Now;
        }
        public void Strat()
        {
            star_time = DateTime.Now;
        }

        public void Draw(PaintEventArgs e)
        {
            int n = (int)((DateTime.Now - star_time).TotalSeconds/(Duration/Frames.Count))%Frames.Count;
            Frames[n].Draw(e);
        }
    }
}
