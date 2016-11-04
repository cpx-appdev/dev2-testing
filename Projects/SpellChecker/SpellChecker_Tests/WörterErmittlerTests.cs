using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using SpellChecker.Resourcen;
using Xunit;


namespace SpellChecker.Test
{
    public class WörterErmittlerTests
    {
        [Fact]
        public void Zerteilt_Text_Korrekt_In_Wörter()
        {
            var wörter = WörterErmittler.WörterErmitteln(new[] {"s1,s2", "s3", "s3", "s3, S3"});

            wörter.ShouldBeEquivalentTo(new[] {"s1", "s2", "s3"});
        }

        [Fact]
        public void Wörter_mit_Tilde_werden_korrekt_gebildet()
        {
            var wörter = WörterErmittler.WörterErmitteln(new[] {"dies,~e,~er,Baum,~es"});

            wörter.ShouldBeEquivalentTo(new[] {"dies", "diese", "dieser", "Baum", "dieses"});
        }

        [Fact]
        public void Wörter_mit_Leerzeichen_werden_gekürzt_sein()
        {
            var wörter = WörterErmittler.WörterErmitteln(new[] { " dies, ~er " });

            wörter.ShouldBeEquivalentTo(new[] { "dies", "dieser" });
        }

        [Fact]
        public void Wenn_das_erste_Wort_einer_Zeile_mit_einer_Tilde_beginnt_soll_Exception_geworfen_werden()
        {
            Action action = () => WörterErmittler.WörterErmitteln(new[] {"~dies"});

            action.ShouldThrow<WortdefinitionUngültigException>();
        }

        [Fact]
        public void Tilde_darf_nur_am_Wortanfang_stehen()
        {
            Action action = () => WörterErmittler.WörterErmitteln(new[] {"d~i~e~s~"});

            action.ShouldThrow<UngültigesWortException>();
        }

        [Fact]
        public void Zeile_die_mit_Komma_startet_soll_Exception_werfen()
        {
            Action action = () => WörterErmittler.WörterErmitteln(new[] {", wort"});
            action.ShouldThrow<LeeresWortInZeileException>();
        }

        [Theory()]
        [InlineData(", wort", typeof(LeeresWortInZeileException), "Wenn das erste Wort einer Zeile mit einer Tilde beginnt soll Exception geworfen werden")]
        [InlineData("d~i~e~s~", typeof(UngültigesWortException), "Tilde darf nur am Wortanfang stehen")]
        [InlineData("~dies", typeof(WortdefinitionUngültigException), "Zeile die mit Komma startet soll Exception werfen")]
        public void Ungültige_Wörterbuchzeilen_sollen_eine_Exception_werfen(string wörterbuchzeile, Type expectedExceptionType, string message)
        {
            Exception ex = null;
            try
            {
                WörterErmittler.WörterErmitteln(new[] { wörterbuchzeile });
            }
            catch (Exception e)
            {
                ex = e;
            }

            if (ex == null)
                Execute.Assertion.FailWith("Es wurde kein Exception geworfen");

            ex.Should().BeOfType(expectedExceptionType, message);
        }
    }
}
