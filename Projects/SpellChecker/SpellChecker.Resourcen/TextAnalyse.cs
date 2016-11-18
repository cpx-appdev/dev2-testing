using System.Collections.Generic;
using System.Linq;

namespace SpellChecker.Resourcen
{
    public interface ITextAnalyse
    {
        EingabeWort[] FindeFalscheWörter(EingabeWort[] eingabeWörter, HashSet<string> wörterbuch);
    }

    public class TextAnalyse : ITextAnalyse
    {
        public EingabeWort[] FindeFalscheWörter(EingabeWort[] eingabeWörter, HashSet<string> wörterbuch)
        {
            return eingabeWörter
                .Where(eingabeWort => !wörterbuch.Contains(eingabeWort.Text))
                .ToArray();
        }
    }
}