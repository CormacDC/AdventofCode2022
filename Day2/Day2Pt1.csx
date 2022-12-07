using System;
using System.IO;
using System.Text;
using Internal;

static int GetWinnerScore(char opponentMove, char yourMove){
  switch (opponentMove)
  {
    case 'A': // rock
      switch (yourMove)
      {
        case 'X': // rock
          return 3;
        case 'Y': // paper
          return 6;
        case 'Z': // scissors
        default:
          return 0;
      }
    case 'B': // paper
      switch (yourMove)
      {
        case 'X': // rock
          return 0;
        case 'Y': // paper
          return 3;
        case 'Z': // scissors
        default:
          return 6;
      }
    case 'C': // scissors
    default:
      switch (yourMove)
      {
        case 'X': // rock
          return 6;
        case 'Y': // paper
          return 0;
        case 'Z': // scissors
        default:
          return 3;
      }
  }
}

static int GetRoundScore(char opponentMove, char yourMove)
{
  switch (yourMove)
  {
    case 'X': // rock
      return GetWinnerScore(opponentMove, yourMove) + 1;
    case 'Y': // paper
      return GetWinnerScore(opponentMove, yourMove) + 2;
    case 'Z': // scissors
    default:
      return GetWinnerScore(opponentMove, yourMove) + 3;
  }
}

static int CalculateStrategyScore()
{
  var input = File.ReadAllText("Day2/Day2.txt");
  var inputArray = input.Split(
    new string[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
  );

  var totalScore = 0;

  foreach (var line in inputArray)
  {
    totalScore += GetRoundScore(line[0], line[2]);
  }

  return totalScore;
}

Internal.Console.WriteLine(CalculateStrategyScore().ToString());
