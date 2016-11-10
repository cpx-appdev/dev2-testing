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

            var falscheWorte = TextAnalyse.FindeFalscheWörter(aufgeteilterText, wörterbuchInhalt);
            return WortAufbereiter.Ausführen(falscheWorte);
        }   
    }
}
