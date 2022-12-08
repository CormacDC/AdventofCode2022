using System;
using System.IO;
using System.Linq;
using System.Text;
using Internal;

static int GetPriorityForSack(String sack)
{
  var firstHalf = sack.Substring(0, sack.Length/2);
  var secondHalf = sack.Substring(sack.Length/2, sack.Length/2);

  var mismatchedLetter = String.Concat(firstHalf.Where(x => secondHalf.Contains(x)))[0];

  return char.IsUpper(mismatchedLetter)
          ? (int)mismatchedLetter - 38 
          : (int)mismatchedLetter - 96;
}

static int CalculatePrioritySum()
{
  var input = File.ReadAllText("Day3/Day3.txt");
  var inputArray = input.Split(
    new string[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
  );

  var totalPriority = 0;

  foreach (var sack in inputArray)
  {
    totalPriority += GetPriorityForSack(sack);
  }

  return totalPriority;
}

Internal.Console.WriteLine(CalculatePrioritySum().ToString());
