using System;
using System.Diagnostics;

namespace Power
{
    class Program
    {
        static void Main(string[] args)
        {
          ITask power = new Power();
          Tester tester = new Tester(power, @".\tests\");
          tester.RunAllTests();
          // tester.RunTest(6);
        }
    }
}
