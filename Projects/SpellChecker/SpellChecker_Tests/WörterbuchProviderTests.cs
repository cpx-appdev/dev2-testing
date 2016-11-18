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
            var wörterbuch = new WörterbuchProvider(new FakeDateiLeser("Ich", "bin", "ein"), new WörterErmittler()).WörterbuchAuslesen();

            // Assert
            wörterbuch.ShouldBeEquivalentTo(new[]
            {
                "Ich", "bin", "ein"
            });
        }
    }
}