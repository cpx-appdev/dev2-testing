using System;
using System.Collections.Generic;
using System.Linq;
using SpellChecker.Resourcen;

namespace SpellChecker.UI
{
    public class Interaktor
    {
        public static IEnumerable<string> Prüfen(string text)
        {
            var aufgeteilterText = TextInWörterZerleger.TextInWoerterZerlegen(text);
            var wörterbuchInhalt = WörterbuchProvider.WörterbuchAuslesen();

            return TextAnalyse.FindeFalscheWörter(aufgeteilterText, wörterbuchInhalt);

        }
    }
}
