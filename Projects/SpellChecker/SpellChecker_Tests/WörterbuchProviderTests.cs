using FluentAssertions;
using SpellChecker.Resourcen;
using Xunit;

namespace SpellChecker.Test
{
    public class WörterbuchProviderTests
    {
        [Fact]
        public void Prüfen_findet_falsche_Wörter()
        {
            // Act
            var wörterbuch = WörterbuchProvider.WörterbuchAuslesen();

            // Assert
            wörterbuch.ShouldBeEquivalentTo(new[]
            {
                "dies", "diese",
                "lorem",
                "ipsum",
                "dolor"
            });
        }
    }
}