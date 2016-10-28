using System;
using System.Collections.Generic;

namespace SpellChecker.Resourcen
{
    public class W�rterErmittler
    {
        public static HashSet<string> W�rterErmitteln(string[] zeilen)
        {
            var w�rterHashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var zeile in zeilen)
            {
                foreach (var wort in zeile.Split(','))
                {
                    w�rterHashSet.Add(wort.Trim());
                }
            }

            return w�rterHashSet;
        }
    }
}