using System;
using System.Diagnostics;

namespace Power
{
    class Program
    {
        static void Main(string[] args)
        {
          double num = 1.001;
          int power = 1000;
          Stopwatch watch = new Stopwatch();
          watch.Start();
          double result = PowerTrivial(num, power);
          watch.Stop();
          string time = watch.Elapsed.TotalMilliseconds.ToString();
          Console.WriteLine($"{num}^{power} using trivial algorithm takes {time} ms.");
        }

        static double PowerTrivial(double number, int pow)
        {
          double result = 1;
          for(int i=0; i<pow; i++)
          {
            result *= number;
          }
          return result;
        }

        static double Power1(double number, int pow)
        {
          return 0;
        }
    }
}
