using System.IO;

namespace SpellChecker.Resourcen
{
    public interface IDateiLeser
    {
        string[] DateiLesen();
    }

    public class DateiLeser : IDateiLeser
    {
        public string[] DateiLesen()
        {
            return File.ReadAllLines("dictionary.txt");
        }
    }
}