using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SpellChecker.Resourcen;
using Xunit;

namespace SpellChecker.Test
{
    public class WörterErmittlerTests
    {


        [Fact]
        public void Zerteilt_Text_Korrekt_In_Wörter()
        {
            var wörter = WörterErmittler.WörterErmitteln(new [] {"s1,s2", "s3", "s3", "s3, S3"});

            wörter.ShouldBeEquivalentTo(new [] { "s1", "s2", "s3"});
        }
    }
}
