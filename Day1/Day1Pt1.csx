using System;
using System.IO;
using System.Text;
using Internal;

static int FattestElf()
{
  var input = File.ReadAllText("Day1/Day1.txt");
  var inputArray = input.Split(
    new string[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
  );

  var fattest = 0;
  var currCalories = 0;

  for (int i = 0; i < inputArray.Length; i++)
  {
    if (inputArray[i] == "" || i == inputArray.Length - 1)
    {
      if (currCalories > fattest)
      {
        fattest = currCalories;
      }
      currCalories = 0;
    } 
    else
    {
      currCalories += Int32.Parse(inputArray[i]);
    }
  }

  return fattest;
}

Console.WriteLine(FattestElf().ToString());