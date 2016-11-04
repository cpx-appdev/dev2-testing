using System;
using System.Collections.Generic;
using System.Linq;

namespace SpellChecker.Resourcen
{
    public class WörterErmittler
    {
        public static HashSet<string> WörterErmitteln(string[] zeilen)
        {
            var wörterHashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            int zeilenNummer = 0;
            foreach (var zeile in zeilen)
            {
                zeilenNummer++;
                var wörterInZeile = zeile.Split(',');
                var wortStamm = wörterInZeile.First().Trim();
                
                if (wortStamm.StartsWith("~"))
                    throw new WortdefinitionUngültigException(wortStamm);
                
                foreach (var wort in wörterInZeile.Select(x => x.Trim()))
                {
                    if (string.IsNullOrWhiteSpace(wort))
                        throw new LeeresWortInZeileException(zeilenNummer);

                    if (wort.Substring(1).Contains("~"))
                        throw new UngültigesWortException(zeilenNummer);

                    if (wort.StartsWith("~"))
                    {
                        wörterHashSet.Add(wortStamm + wort.Substring(1));
                    }
                    else
                    {
                        wörterHashSet.Add(wort);
                    }
                }
            }

            return wörterHashSet;
        }
    }
}