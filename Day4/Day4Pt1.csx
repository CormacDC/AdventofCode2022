using System;
using System.IO;
using System.Linq;
using System.Text;

static int GetContainingRanges()
{
  var input = File.ReadAllText("Day4/Day4.txt");
  var inputArray = input.Split(
    new string[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
  );

  var totalContainingRanges = 0;

  foreach (var line in inputArray)
  {
    var splitLine = line.Split(',');
    var firstRange = splitLine[0].Split('-').Select(x => Int32.Parse(x));
    var secondRange = splitLine[1].Split('-').Select(x => Int32.Parse(x));

    if (firstRange.ElementAt(0) <= secondRange.ElementAt(0) 
        && firstRange.ElementAt(1) >= secondRange.ElementAt(1)
        || 
        secondRange.ElementAt(0) <= firstRange.ElementAt(0) 
        && secondRange.ElementAt(1) >= firstRange.ElementAt(1))
    {
      totalContainingRanges++;
    }
  }

  return totalContainingRanges;
}

Console.WriteLine(GetContainingRanges());
