using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kostka kostka = new Kostka();

            string jmeno1 = textBox1.Text;
            Bojovnik bojovnik1 = new Bojovnik(jmeno1, 80, 20, 10, kostka);
            bojovnik1.ZivotGraficky(label5, progressBar1);

            string jmeno2 = textBox2.Text;
            Bojovnik bojovnik2 = new Bojovnik(jmeno2, 60, 15, 10, kostka);
            bojovnik2.ZivotGraficky(label6, progressBar2);

            Bojovnik b1 = bojovnik1;
            Bojovnik b2 = bojovnik2;

            bool zacinaBojovnik2 = (kostka.hod() <= kostka.VratPocetSten() / 2);
            if (zacinaBojovnik2)
            {
                b1 = bojovnik2;
                b2 = bojovnik1;
            }

            MessageBox.Show(String.Format("Začínat bude bojovník {0}! \nZápas může začít...", b1.ToString()));
            while (b1.Nazivu() && b2.Nazivu())
            {
                b1.Utoc(b2);

                MessageBox.Show(b1.VratPosledniZpravu()); // zpráva o útoku
                MessageBox.Show(b2.VratPosledniZpravu()); // zpráva o obraně

                bojovnik1.ZivotGraficky(label5, progressBar1);
                bojovnik2.ZivotGraficky(label6, progressBar2);

                if (b2.Nazivu())
                {
                    b2.Utoc(b1);

                    MessageBox.Show(b2.VratPosledniZpravu()); // zpráva o útoku
                    MessageBox.Show(b1.VratPosledniZpravu()); // zpráva o obraně

                    bojovnik1.ZivotGraficky(label5, progressBar1);
                    bojovnik2.ZivotGraficky(label6, progressBar2);
                }
            }
        }

    private void Form1_Load(object sender, EventArgs e)
        {
            Random obr = new Random();
            int cisloObr = obr.Next(0, 8);
            cisloObr = obr.Next(0, 8);
        }
    }
}
