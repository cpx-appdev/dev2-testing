using System.Collections.Generic;

namespace SpellChecker.Resourcen
{
    public class W�rterbuchProvider
    {
        public static HashSet<string> W�rterbuchAuslesen()
        {
            var zeilen = DateiLeser.DateiLesen();
            return W�rterErmittler.W�rterErmitteln(zeilen);
        }
    }
}