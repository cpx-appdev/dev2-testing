using System;
using System.Collections.Generic;
using System.Linq;

namespace SpellChecker.Resourcen
{
    public class W�rterErmittler
    {
        public static HashSet<string> W�rterErmitteln(string[] zeilen)
        {
            var w�rterHashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            int zeilenNummer = 0;
            foreach (var zeile in zeilen)
            {
                zeilenNummer++;
                var w�rterInZeile = zeile.Split(',');
                var wortStamm = w�rterInZeile.First().Trim();
                
                if (wortStamm.StartsWith("~"))
                    throw new WortdefinitionUng�ltigException(wortStamm);
                
                foreach (var wort in w�rterInZeile.Select(x => x.Trim()))
                {
                    if (string.IsNullOrWhiteSpace(wort))
                        throw new LeeresWortInZeileException(zeilenNummer);

                    if (wort.Substring(1).Contains("~"))
                        throw new Ung�ltigesWortException(zeilenNummer);

                    if (wort.StartsWith("~"))
                    {
                        w�rterHashSet.Add(wortStamm + wort.Substring(1));
                    }
                    else
                    {
                        w�rterHashSet.Add(wort);
                    }
                }
            }

            return w�rterHashSet;
        }
    }
}