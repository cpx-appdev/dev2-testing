using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SpellChecker.Resourcen;
using Xunit;

namespace SpellChecker.Test
{
    
    public class WortAufbereiterTests
    {
        [Fact]
        public void Worte_werden_mit_Positionen_aufbereitet()
        {
            var wörter = new[]
            {
                new EingabeWort("Hallo", 0, 0),
                new EingabeWort("Welt", 0, 6),
                new EingabeWort("Hallo", 1, 0)
            };

            var formatierteWörter = new WortAufbereiter().Ausführen(wörter);

            formatierteWörter.ShouldBeEquivalentTo(new [] {"Hallo [1,1;2,1]", "Welt [1,7]"});
        }
    }
}
