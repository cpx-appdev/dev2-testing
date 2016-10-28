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
            var wörter = TextInWörterZerleger.TextInWoerterZerlegen("Hallo das ist\nein\r\nTest.");

            
            wörter.ShouldBeEquivalentTo(new [] { "Hallo", "das", "ist", "ein", "Test" });
        }
    }
}
