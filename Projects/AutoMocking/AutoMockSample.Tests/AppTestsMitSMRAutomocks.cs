using NSubstitute;
using Xunit;

namespace AutoMockSample.Tests
{
    public class AppTestsMitSMRAutomocks : WithAutoMock
    {
        [Fact]
        public void Das_vom_Calculator_berechnete_Ergebniss_wird_ausgegeben()
        {
            //ARRANGE
            The<ICalculator>().Add(1, 1).ReturnsForAnyArgs(2);

            //ACT
            CreateInstance<App>().Run();

            //ASSERT
            The<IOutput>().Received(1).Write("Summe: 2\n");
        }
    }
}