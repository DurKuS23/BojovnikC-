using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DU
{
    internal class Kostka
    {
        private Random random;
        private int pocetSten;

        public Kostka()
        {
            pocetSten = 6;
            random = new Random();
        }

        public int VratPocetSten()
        {
            return pocetSten;
        }

        public Kostka (int aPocetSten)
        {
            pocetSten = aPocetSten;
            random = new Random();
        }

        public int hod()
        {
            return random.Next(1, pocetSten + 1);
        }
    }
}
