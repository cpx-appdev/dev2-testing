using NSubstitute;
using Xunit;

namespace AutoMockSample.Tests
{
    public class AppTestsOhneAutomocking
    {
        [Fact]
        public void Das_vom_Calculator_berechnete_Ergebniss_wird_ausgegeben()
        {
            //ARRANGE
            var output = Substitute.For<IOutput>();
            var input = Substitute.For<IInput>();
            var calculator = Substitute.For<ICalculator>();
            var logger = Substitute.For<ILogging>();

            calculator.Add(1, 1).ReturnsForAnyArgs(2);

            var app = new App(output, input, calculator, logger);

            //ACT
            app.Run();

            //ASSERT
            output.Received(1).Write("Summe: 2\n");
        }
    }
}
