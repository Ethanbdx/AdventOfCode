using System.Drawing;

namespace AdventOfCodeCSharp.Day2
{
    public static class Day2Solution
    {
        public static int SolvePart1()
        {
            var streamReader = new StreamReader("./Day2/Day2Input.txt");

            var gameIdSum = 0;

            var cubeMaxAmounts = new Dictionary<string, int>
            {
                {"red", 12 },
                {"green", 13 },
                {"blue", 14 }
            };

            while(!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                var gameInputs = line.Split(":");
                var gameId = int.Parse(gameInputs[0].Substring(4));
                var isGamePossible = true;

                var reveals = gameInputs[1].Split(';');
                foreach(var reveal in reveals)
                {
                    
                    var cubesRevealed = reveal.Split(',');
                    foreach(var rawCubeInput in cubesRevealed)
                    {
                        var cubeInput = rawCubeInput.Trim().Split(' ');
                        var amount = int.Parse(cubeInput[0]);
                        var color = cubeInput[1];
                        if (cubeMaxAmounts[color] < amount)
                        {
                            isGamePossible = false;
                            Console.WriteLine($"[Game {gameId}] - {color} exceeded maximum value. Value: {amount}, Max: {cubeMaxAmounts[color]}");
                            break;
                        }
                    }            
                }

                if (isGamePossible)
                {
                    gameIdSum += gameId;
                }
            }
            return gameIdSum;
        }
    }
}
