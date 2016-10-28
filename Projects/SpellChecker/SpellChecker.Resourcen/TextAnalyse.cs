using System.Collections.Generic;
using System.Linq;

namespace SpellChecker.Resourcen
{
    public class TextAnalyse

    {
        public static IEnumerable<string> FindeFalscheWörter(string[] eingabeText, HashSet<string> wörterbuch)
        {
            return eingabeText.Except(wörterbuch);
        }
    }
}