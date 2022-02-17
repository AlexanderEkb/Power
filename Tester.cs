using System.Globalization;

namespace Power

{
  internal class Tester
  {
    private ITask task;
    private string path;
    private string[] data = {};
    // private string expect = "";
    // private string actual = "";
    public Tester(ITask task, string path)
    {
      this.task = task;
      this.path = path;
    }
    public void RunAllTests()
    {
      int count = 0;
      while(true)
      {
        bool result = RunTest(count);
        if(!result)
        {
          break;
        }
        count++;
      }
    }

    public bool RunTest(int count)
    {
      string inFile = $"{path}test.{count}.in";
      string outFile = $"{path}test.{count}.out";
      if(!File.Exists(inFile) || !File.Exists(outFile))
      {
        return false;
      }
      RunTest(inFile, outFile, count);
      return true;
    }
    bool RunTest(string inFile, string outFile, int count)
    {
      try
      {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.NumberDecimalSeparator = ".";
        
        data = File.ReadAllLines(inFile);
        double expect = double.Parse(File.ReadAllText(outFile).Trim(), nfi);
        double actual = double.Parse(task.Run(data).Trim(), nfi);
        bool result = (actual == expect);
        if(result)
        {
          Console.WriteLine($"Test #{count} - PASS");
        }
        else
        {
          Console.WriteLine($"Test #{count} - FAIL ({expect} != {actual})");
        }
        return actual == expect;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }
    }
  }
}