using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ClickPower
    {
        private DateTime start_time;

        public double ChargeTime;

        public ClickPower()
        {
            start_time = new DateTime();
            start_time = DateTime.Now;
        }

        public void Srart()
        {
            start_time = DateTime.Now;
        }
        public int GetPower()
        {
            double x = 300.0 / Math.Pow(ChargeTime, 3);
            double t = (DateTime.Now - start_time).TotalSeconds % (ChargeTime * 2);
            if(t < ChargeTime)
            {
                return (int)(x * Math.Pow(t, 3) / 3);
            }
            else
            {
                return (int)(x * Math.Pow(2 * ChargeTime - t, 3) / 3);
            }
        }
    }
}
