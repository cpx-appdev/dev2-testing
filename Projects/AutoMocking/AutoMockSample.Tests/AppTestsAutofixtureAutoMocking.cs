using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Xunit;

namespace AutoMockSample.Tests
{
    public class AppTestsAutofixtureAutoMocking
    {
        //DOCS: http://blog.ploeh.dk/2010/08/19/AutoFixtureasanauto-mockingcontainer/
        [Fact]
        public void Das_vom_Calculator_berechnete_Ergebniss_wird_ausgegeben()
        {
            //ARRANGE
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            var calculator = fixture.Freeze(Substitute.For<ICalculator>());
            var console = fixture.Freeze(Substitute.For<IOutput>());
            var app = fixture.Create<App>();

            calculator.Add(1, 1).ReturnsForAnyArgs(2);

            //ACT
            app.Run();

            //ASSERT
            console.Received(1).Write("Summe: 2\n");
        }
    }
}