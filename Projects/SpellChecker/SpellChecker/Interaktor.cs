using System;
using System.Collections.Generic;
using System.Linq;
using SpellChecker.Resourcen;

namespace SpellChecker.UI
{
    public class Interaktor
    {
        private readonly ITextInWörterZerleger _textInWörterZerleger;
        private readonly IWörterbuchProvider _wörterbuchProvider;
        private readonly ITextAnalyse _textAnalyse;
        private readonly IWortAufbereiter _wortAufbereiter;

        public Interaktor(ITextInWörterZerleger textInWörterZerleger,
            IWörterbuchProvider wörterbuchProvider,
            ITextAnalyse textAnalyse,
            IWortAufbereiter wortAufbereiter)
        {
            _textInWörterZerleger = textInWörterZerleger;
            _wörterbuchProvider = wörterbuchProvider;
            _textAnalyse = textAnalyse;
            _wortAufbereiter = wortAufbereiter;
        }

        public IEnumerable<string> Prüfen(string text)
        {
            var aufgeteilterText = _textInWörterZerleger.TextInWoerterZerlegen(text);
            var wörterbuchInhalt = _wörterbuchProvider.WörterbuchAuslesen();

            var falscheWorte = _textAnalyse.FindeFalscheWörter(aufgeteilterText, wörterbuchInhalt);
            return _wortAufbereiter.Ausführen(falscheWorte);
        }   
    }
}
