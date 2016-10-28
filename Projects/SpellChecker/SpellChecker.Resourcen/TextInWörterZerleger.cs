using System;
using System.Linq;

namespace SpellChecker.Resourcen
{
    public class TextInWörterZerleger
    {
        public static string[] TextInWoerterZerlegen(string text)
        {
            return text.Split(new[] {" ", "\t", "\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim('.', ',', ';', '?', '!'))
                .ToArray();
        }
    }
}