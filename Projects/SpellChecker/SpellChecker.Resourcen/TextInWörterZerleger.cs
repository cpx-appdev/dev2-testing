using System;
using System.Collections.Generic;
using System.Linq;

namespace SpellChecker.Resourcen
{
    public class TextInWörterZerleger
    {
        public static EingabeWort[] TextInWoerterZerlegen(string text)
        {
            var eingabeWörter = new List<EingabeWort>();
            var zeilen = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (var zeilenIndex = 0; zeilenIndex < zeilen.Length; zeilenIndex++)
            {
                var wörter = zeilen[zeilenIndex].Split(new[] { " ", "\t" }, StringSplitOptions.None);
                int spaltenIndex = 0;
                for (var wortIndex = 0; wortIndex < wörter.Length; wortIndex++)
                {
                    var wort = wörter[wortIndex];
                    eingabeWörter.Add(new EingabeWort(wort, zeilenIndex, spaltenIndex));
                    spaltenIndex += wort.Length + 1;
                }
            }

            return eingabeWörter.ToArray();
        }
    }
}