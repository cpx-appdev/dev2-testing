using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Resourcen
{
    public class WortAufbereiter
    {
        public static string[] Ausführen(EingabeWort[] wörter)
        {
            var formatierteWorte = new List<string>();

            foreach (var wortGruppe in wörter.GroupBy(x => x.Text))
            {
                var rückgabe = new StringBuilder();

                var wort = wortGruppe.Key;

                rückgabe.Append(wort);
                rückgabe.Append(" [");
                var positionen = wortGruppe.Select(wortGruppenEintrag => $"{wortGruppenEintrag.Zeile + 1},{wortGruppenEintrag.Spalte + 1}").ToList();
                rückgabe.Append(string.Join(";", positionen));
                rückgabe.Append("]");
                formatierteWorte.Add(rückgabe.ToString());

                
            }

            return formatierteWorte.ToArray();
        }
    }
}
