using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    class SingleFrame
    {
        public Bitmap View;
        public Point Location;
        public Size Size;

        public SingleFrame()
        {
            View = null;
            Location = new Point(0, 0);
            Size = new Size(0, 0);

        }
        public SingleFrame(Bitmap bmp, Point loc, Size s)
        {
            View = bmp;
            Location = loc;
            Size = s;

        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(View, new Rectangle(new Point(0, 0), Size), new Rectangle(Location, Size), GraphicsUnit.Pixel);
        }
    }
}
