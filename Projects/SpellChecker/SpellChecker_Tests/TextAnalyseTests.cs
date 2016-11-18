using System.Collections.Generic;
using FluentAssertions;
using SpellChecker.Resourcen;
using Xunit;

namespace SpellChecker.Test
{
    public class TextAnalyseTests
    {
        [Fact]
        public void FindeFalscheWörter_Gibt_die_Wörter_Zurück_Die_Nicht_Im_Wörterbuch_Sind()
        {
            // Arrange
            var eingabeText = new[]
            {
                new EingabeWort("s1", 0, 0),
                new EingabeWort("s2", 1, 0)
            };
            var wörterbuch = new HashSet<string> {"s1"};
            
            // Act
            var result = new TextAnalyse().FindeFalscheWörter(eingabeText, wörterbuch);

            // Assert
            result.ShouldBeEquivalentTo(new[] { eingabeText[1] });
        }
    }
}