using System;
using System.Diagnostics;
using System.Globalization;

namespace Power
{
    class Power : ITask
    {
        public string Run(string[] data)
        {
          NumberFormatInfo nfi = new NumberFormatInfo();
          nfi.NumberDecimalSeparator = ".";

          double N = double.Parse(data[0], nfi);
          int P = Convert.ToInt32(data[1]);
          Stopwatch watch = new Stopwatch();
          watch.Start();
          double answer = PowerTrivial(N, P);
          watch.Stop();
          string time = watch.Elapsed.TotalMilliseconds.ToString();

          nfi.NumberDecimalDigits = 5;
          string AnswerAsString = answer.ToString("F11", nfi);
          Console.Write($"{N}^{P}={AnswerAsString} using trivial algorithm takes {time} ms, ");
          return AnswerAsString;
        }

        public double PowerTrivial(double N, long P)
        {
          if(P == 0)
            return 1;
          else
          {
            double result = 1;
            for(int i=0; i<P; i++)
            {
              result *= N;
            }
            return result;
          }
        }
    }
}
