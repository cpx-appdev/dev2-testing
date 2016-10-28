using System.IO;

namespace SpellChecker.Resourcen
{
    public class DateiLeser
    {
        public static string[] DateiLesen()
        {
            return File.ReadAllLines("dictionary.txt");
        }
    }
}