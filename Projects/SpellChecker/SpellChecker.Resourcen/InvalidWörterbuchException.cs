using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Resourcen
{
    public class WortdefinitionUngültigException : ArgumentException
    {
        public WortdefinitionUngültigException(string ungültigesWort) : base($"Wortdefinition ungültig: {ungültigesWort}")
        {
            
        }
    }

    public class LeeresWortInZeileException : ArgumentException
    {
        public LeeresWortInZeileException(int zeilenNummer) : base($"Leeres Wort in Zeile {zeilenNummer} sind nicht erlaubt.")
        {

        }
    }

    public class UngültigesWortException : ArgumentException
    {
        public UngültigesWortException(int zeilenNummer) : base($"Ungültiges Wort in Zeile {zeilenNummer} sind nicht erlaubt.")
        {
        }
    }
}
