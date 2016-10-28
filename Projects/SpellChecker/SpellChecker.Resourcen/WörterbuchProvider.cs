using System.Collections.Generic;

namespace SpellChecker.Resourcen
{
    public class WörterbuchProvider
    {
        public static HashSet<string> WörterbuchAuslesen()
        {
            var zeilen = DateiLeser.DateiLesen();
            return WörterErmittler.WörterErmitteln(zeilen);
        }
    }
}