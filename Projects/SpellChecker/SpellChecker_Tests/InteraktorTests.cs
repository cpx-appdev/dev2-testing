using FluentAssertions;
using SpellChecker.UI;
using Xunit;

namespace SpellChecker.Test
{
    public class InteraktorTests
    {
        [Fact]
        public void Prüfen_findet_falsche_Wörter()
        {
            // Arrange
            var text = "lorem ipsum dolor sit amet.";

            // Act
            var fehlerhafteWörter = Interaktor.Prüfen(text);

            // Assert
            fehlerhafteWörter.ShouldBeEquivalentTo(new[] { "sit", "amet" });
        }
    }
}
