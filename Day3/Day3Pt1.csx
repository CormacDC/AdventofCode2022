using System;
using System.IO;
using System.Linq;
using System.Text;

static int GetPriorityForSack(String sack)
{
  var firstHalf = sack.Substring(0, sack.Length/2);
  var secondHalf = sack.Substring(sack.Length/2, sack.Length/2);

  var mismatchedLetter = String.Concat(firstHalf.Where(x => secondHalf.Contains(x)))[0];

  return char.IsUpper(mismatchedLetter)
          ? (int)mismatchedLetter - 38 // ascii value of A is 65 & we want 27 thru 52
          : (int)mismatchedLetter - 96; // ascii value of a is 97 & we want 1 thru 26
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

Console.WriteLine(CalculatePrioritySum().ToString());
