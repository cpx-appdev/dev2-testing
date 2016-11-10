using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Resourcen
{
    public class EingabeWort
    {
        public EingabeWort(string text, int zeile, int spalte)
        {
            Text = text;
            Zeile = zeile;
            Spalte = spalte;
        }
        public string Text { get; set; }

        public int Zeile { get; set; }

        public int Spalte { get; set; }
    }
}
