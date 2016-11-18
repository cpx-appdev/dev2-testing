using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SpellChecker.Resourcen;
using Xunit;

namespace SpellChecker.Test
{
    public class TextInWörterZerlegerTests
    {
        [Fact]
        public void Zerlege_Text_Korrekt_In_Wörter()
        {
            var wörter = new TextInWörterZerleger().TextInWoerterZerlegen("Hallo Welt\nHallo");

            wörter.ShouldBeEquivalentTo(new[]
            {
                new EingabeWort ("Hallo", 0, 0 ),
                new EingabeWort ("Welt", 0, 6 ),
                new EingabeWort ("Hallo",1, 0 )
            });
        }
    }
}
