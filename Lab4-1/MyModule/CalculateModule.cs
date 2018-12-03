using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModule
{
    public class CalculateModule
    {
        public int A { get; set; }
        public int B { get; set; }

        public int Calcukate(string op)
        {
            int r = 0;
            switch(op)
            {
                case "+":
                    r = A + B;
                    break;
                case "-":
                    r = A - B;
                    break;
                case "*":
                    r = A * B;
                    break;
                case "/":
                    r = A / B;
                    break;
            }
            return r;
        }
    }
}
