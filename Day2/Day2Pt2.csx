using System;
using System.IO;
using System.Text;

static int GetWinnerScore(char opponentMove, char yourMove){
  switch (opponentMove)
  {
    case 'A': // rock
      switch (yourMove)
      {
        case 'X': // lose
          return 3; // scissors
        case 'Y': // draw
          return 1; // rock
        case 'Z': // win
        default:
          return 2; // paper
      }
    case 'B': // paper
      switch (yourMove)
      {
        case 'X': // lose
          return 1; // rock
        case 'Y': // draw
          return 2; // paper
        case 'Z': // win
        default:
          return 3; // scissors
      }
    case 'C': // scissors
    default:
      switch (yourMove)
      {
        case 'X': // lose
          return 2; // paper
        case 'Y': // draw
          return 3; // scissors
        case 'Z': // win
        default:
          return 1; // rock
      }
  }
}

static int GetRoundScore(char opponentMove, char yourMove)
{
  switch (yourMove)
  {
    case 'X': // lose
      return GetWinnerScore(opponentMove, yourMove) + 0;
    case 'Y': // draw
      return GetWinnerScore(opponentMove, yourMove) + 3;
    case 'Z': // win
    default:
      return GetWinnerScore(opponentMove, yourMove) + 6;
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

Console.WriteLine(CalculateStrategyScore().ToString());
