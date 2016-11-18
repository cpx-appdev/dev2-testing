using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellChecker.Resourcen;

namespace SpellChecker.Test
{
    class FakeDateiLeser : IDateiLeser
    {
        private string[] _zeilen;

        public FakeDateiLeser(params string[] zeilen)
        {
            _zeilen = zeilen;
        }

        public string[] DateiLesen()
        {
            return _zeilen;
        }
    }
}
