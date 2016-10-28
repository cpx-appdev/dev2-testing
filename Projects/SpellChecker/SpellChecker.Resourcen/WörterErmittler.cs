using System;
using System.Collections.Generic;

namespace SpellChecker.Resourcen
{
    public class WörterErmittler
    {
        public static HashSet<string> WörterErmitteln(string[] zeilen)
        {
            var wörterHashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var zeile in zeilen)
            {
                foreach (var wort in zeile.Split(','))
                {
                    wörterHashSet.Add(wort.Trim());
                }
            }

            return wörterHashSet;
        }
    }
}