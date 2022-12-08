using System;
using System.IO;
using System.Linq;
using System.Text;

static String GetCrateMessage()
{
  var input = File.ReadAllText("Day5/Day5.txt");
  var inputArray = input.Split(
    new string[] { "\r\n\r\n" },
    StringSplitOptions.RemoveEmptyEntries
  );
  
  var crates = inputArray[0];
  var instructions = inputArray[1].Split(
    new string[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
  );

  return "";
}

GetCrateMessage();
