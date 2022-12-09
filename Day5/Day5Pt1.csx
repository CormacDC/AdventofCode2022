using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

// these are probably the worst algorithms I've ever written, but hey they work *cries in O(n^2)*

static Dictionary<int,Stack<char>> getCrateStacks(String[] crateArray, int numStacks)
{
  var crateStacks = new Dictionary<int,Stack<char>>();
  for (int i = 1; i <= numStacks; i++)
  {
    crateStacks.Add(i, new Stack<char>());
  }

  for (int i = crateArray.Length - 2; i >= 0; i--)
  {
    var stackNum = 1;
    for (int j = 1; stackNum <= numStacks; j += 4)
    {
      if (crateArray[i][j] != ' ') 
      {
        crateStacks[stackNum].Push(crateArray[i][j]);
      }
      stackNum++;
    }
  }

  return crateStacks;
}

static Dictionary<int,Stack<char>> shuffleCrates(Dictionary<int,Stack<char>> crateStacks, String[] instructions)
{
  var localStacks = crateStacks;

  foreach (var instruction in instructions)
  {
    var instructionNumbers = Regex.Split(instruction, @"\D+");

    var move = Int32.Parse(instructionNumbers[1]);
    var from = Int32.Parse(instructionNumbers[2]);
    var to = Int32.Parse(instructionNumbers[3]);

    for (int i = 0; i < move; i++)
    {
      var fromVal = localStacks[from].Pop();
      localStacks[to].Push(fromVal);
    }
  }

  return localStacks;
}

static String getTopCrateMessage(Dictionary<int,Stack<char>> crateStacks, int numStacks)
{
  var message = "";

  for (int i = 1; i <= numStacks; i++)
  {
    message = $"{message}{crateStacks[i].Peek()}";
  }

  return message;
}

static String GetCrateMessage()
{
  var input = File.ReadAllText("Day5/Day5.txt");
  var inputArray = input.Split(
    new String[] { "\r\n\r\n" },
    StringSplitOptions.RemoveEmptyEntries
  );
  
  var crateArray = inputArray[0].Split(
    new String[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
  );
  var instructions = inputArray[1].Split(
    new String[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
  );

  var numStacks = 9;
  
  var crateStacks = getCrateStacks(crateArray, numStacks);

  var shuffledStacks = shuffleCrates(crateStacks, instructions);

  var message = getTopCrateMessage(shuffledStacks, numStacks);

  return message;
}

Console.WriteLine(GetCrateMessage());
