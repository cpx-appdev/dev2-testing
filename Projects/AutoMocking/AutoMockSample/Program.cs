namespace AutoMockSample
{
    class Program
    {
        static void Main(string[] args)
        {
            new App(new Output(), new Input(), new Calculator(), new Logging()).Run();
        }
    }
}
