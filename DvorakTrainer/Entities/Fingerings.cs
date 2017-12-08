using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvorakTrainer.Entities
{
    public class Fingerings
    {

        public int O { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public Fingerings(int o, int r, int g, int b)
        {
            O = o;
            R = r;
            G = g;
            B = b;
        }

    }
}
