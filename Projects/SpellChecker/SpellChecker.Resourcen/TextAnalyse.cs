using System.Collections.Generic;
using System.Linq;

namespace SpellChecker.Resourcen
{
    public class TextAnalyse
    {
        public static EingabeWort[] FindeFalscheWörter(EingabeWort[] eingabeWörter, HashSet<string> wörterbuch)
        {
            return eingabeWörter
                .Where(eingabeWort => !wörterbuch.Contains(eingabeWort.Text))
                .ToArray();
        }
    }
}