using System;
using System.IO;
using System.Linq;
using System.Text;
using Internal;

static int GetPriorityForGroup(String[] group)
{
  var priorityLetter = String.Concat(group[0].Where(x => group[1].Contains(x) && group[2].Contains(x)))[0];

  return char.IsUpper(priorityLetter)
          ? (int)priorityLetter - 38 // ascii value of A is 65 & we want 27 thru 52
          : (int)priorityLetter - 96; // ascii value of a is 97 & we want 1 thru 26
}

static int CalculatePrioritySum()
{
  var input = File.ReadAllText("Day3/Day3.txt");
  var inputArray = input.Split(
    new string[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
  );

  var totalPriority = 0;

  for (int i = 0; i <= inputArray.Length - 3; i += 3)
  {
    var group = new[] 
    {
      inputArray[i],
      inputArray[i+1],
      inputArray[i+2]
    };
    
    totalPriority += GetPriorityForGroup(group);
  }

  return totalPriority;
}

Internal.Console.WriteLine(CalculatePrioritySum().ToString());
