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
            var eingabeText = new[] {"s1", "s2"};
            var wörterbuch = new HashSet<string> {"s1"};
            
            // Act
            var result = TextAnalyse.FindeFalscheWörter(eingabeText, wörterbuch);

            // Assert
            result.ShouldBeEquivalentTo(new[] { "s2" });
        }
    }
}