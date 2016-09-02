namespace AutoMockSample
{
    public interface IOutput
    {
        void Write(string msg);
    }

    public class Output : IOutput
    {
        public int ReadInt()
        {
            return int.Parse(System.Console.ReadLine());
        }

        public void Write(string msg)
        {
            System.Console.Write(msg);
        }
    }
}