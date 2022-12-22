using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DU
{
    internal class Bojovnik
    {
        private string jmeno;
        private int utok;
        private int zivot;
        private int obrana;
        private Kostka kostka;
        private string zprava;

        public Bojovnik(string jmeno, int zivot, int utok, int obrana, Kostka kostka)
        {
            this.jmeno = jmeno;
            this.zivot = zivot;
            this.utok = utok;
            this.obrana = obrana;
            this.kostka = kostka;
        }

        public override string ToString()
        {
            return "Jmeno bojovnika: " + jmeno;
        }

        public int vratZivot()
        {
            return zivot;
        }

        public bool Nazivu()
        {
            return (zivot > 0);
        }

        public void ZivotGraficky(Label l, ProgressBar p)
        {
            l.Text = this.vratZivot().ToString();
            p.Value = this.vratZivot();
        }

        public void BranSe(int uder)
        {
            int zraneni = uder - (obrana + kostka.hod());
            if (zraneni > 0)
            {
                zivot -= zraneni;
                zprava = String.Format("{0} utrpěl poškození {1} hp", jmeno, zraneni);
                if (zivot < 0)
                {
                    zivot = 0;
                    zprava += " a zemřel";
                }
            }
            else
            {
                zprava = String.Format("{0} odrazil útok", jmeno);
            }
            NastavZpravu(zprava);
        }

        public void Utoc (Bojovnik souper)
        {
            int uder = utok + kostka.hod();
            NastavZpravu(String.Format("{0} útočí s úderem za {1} hp", jmeno, uder));
            souper.BranSe(uder);
        }

        private void NastavZpravu(string zprava)
        {
            this.zprava = zprava;
        }
        public string VratPosledniZpravu()
        {
            return zprava;
        }


    }
}
