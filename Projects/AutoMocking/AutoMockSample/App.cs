namespace AutoMockSample
{
    public class App
    {
        private readonly IOutput _output;
        private readonly IInput _input;
        private readonly ICalculator _calculator;
        private readonly ILogging _logging;

        public App(IOutput output, IInput input, ICalculator calculator, ILogging logging)
        {
            _output = output;
            _input = input;
            _calculator = calculator;
            _logging = logging;
        }

        public void Run()
        {
            _output.Write("Bitte eine Zahl eingeben: ");
            var n1 = _input.ReadInt();

            _output.Write("Bitte eine zweite Zahl eingeben: ");
            var n2 = _input.ReadInt();

            _logging.Info("Es wird die Summe aus {n1} und {n2} berechnet.");

            var sum = _calculator.Add(n1, n2);
            _output.Write($"Summe: {sum}\n");
        }
    }
}