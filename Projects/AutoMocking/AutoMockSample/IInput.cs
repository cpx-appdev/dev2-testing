using System;

namespace AutoMockSample
{
    public interface IInput
    {
        int ReadInt();
    }

    class Input : IInput
    {
        public int ReadInt()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}