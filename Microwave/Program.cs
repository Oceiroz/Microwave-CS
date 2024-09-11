using System;
using System.Threading.Tasks;
using System.Threading;

namespace Microwave
{
    class Program
    {
        static void Main(string[] args)
        {
            StartCycle();
        }
        static T GetInput<T>(string inputMessage)
        {
            T userInput;
            while (true)
            {
                Console.WriteLine($"{inputMessage}\n");
                string rawInput = Console.ReadLine();
                try
                {
                    userInput = (T)Convert.ChangeType(rawInput, typeof(T));
                    break;
                }
                catch(FormatException)
                {
                    Console.WriteLine("This is the wrong data type...");
                }
            }
            return userInput;
        }
        static void StartCycle()
        {
            int time = GetInput<int>("Microwave time in seconds");
            MMMMMM(time);
        }
        static void EndCycle()
        {
            for (int x = 0; x < 3; x++)
            {
                MakeSound(3000, 1);
                Thread.Sleep(500);
            }
        }
        static async Task MMMMMM(int time)
        {
            int timeDelay = time;
            Task beepHigh = Task.Run(() => MakeSound(120, time));
            Task beepLow = Task.Run(() => MakeSound(100, time));
            for (; 0 <= time; time--)
            {
                Console.WriteLine(time);
                Thread.Sleep(1000);
            }
            await Task.WhenAll(beepHigh, beepLow);
            EndCycle();
        }

        static void MakeSound(int frequency, int time)
        {
            int trueTime = time * 1000;
            System.Console.Beep(frequency, trueTime);
        }
    }
}
