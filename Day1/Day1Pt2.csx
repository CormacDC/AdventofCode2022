using System;
using System.IO;
using System.Text;

static int ThreeFattestElves()
{
  var input = File.ReadAllText("Day1/Day1.txt");
  var inputArray = input.Split(
    new string[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
  );

  var firstFattest = 0;
  var secondFattest = 0;
  var thirdFattest = 0;
  var currCalories = 0;

  for (int i = 0; i < inputArray.Length; i++)
  {
    if (inputArray[i] == "" || i == inputArray.Length - 1)
    {
      if (currCalories > firstFattest)
      {
        thirdFattest = secondFattest;
        secondFattest = firstFattest;
        firstFattest = currCalories;
      }
      else if (currCalories > secondFattest)
      {
        thirdFattest = secondFattest;
        secondFattest = currCalories;
      }
      else if (currCalories > thirdFattest)
      {
        thirdFattest = currCalories;
      }
      currCalories = 0;
    } 
    else
    {
      currCalories += Int32.Parse(inputArray[i]);
    }
  }

  return firstFattest + secondFattest + thirdFattest;
}

Console.WriteLine(ThreeFattestElves().ToString());