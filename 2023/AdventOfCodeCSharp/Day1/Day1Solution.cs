using System.Text;

namespace AdventOfCodeCSharp.Day1
{
    public static class Day1Solution
    {
        public static int SolvePart1()
        {
            var lines = File.ReadAllLines("./Day1/Day1Input.txt");
            var sum = 0;
            foreach (var line in lines)
            {
                sum += DetermineNumber(line);
            }

            return sum;
        }

        private static int DetermineNumber(string line)
        {
            var validNumbers = line
                .Where(x => int.TryParse(x.ToString(), out _))
                .Select(x => int.Parse(x.ToString()))
                .ToList();

            return (validNumbers.First() * 10) + validNumbers.Last();
        }

        public static int SolvePart2()
        {
            var lines = File.ReadAllLines("./Day1/Day1Input.txt");

            var sum = 0;
            foreach (var line in lines)
            {
                sum += DetermineNumberPart2(line);
            }

            return sum;
        }

        public static int DetermineNumberPart2(string line)
        {
            var numberDictionary = new Dictionary<string, int>
            {
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4 },
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8 },
                {"nine", 9 }
            };

            int? firstNumber = null;
            int? lastNumber = null;

            int index = 0;
            while(firstNumber == null)
            {
                if (int.TryParse(line[index].ToString(), out var digit))
                {
                    firstNumber = digit * 10;
                }

                var section = line.Substring(0, index);
                if (numberDictionary.Any(x => section.Contains(x.Key)))
                {
                    firstNumber = numberDictionary.Where(x => section.Contains(x.Key)).First().Value * 10;
                }

                index++;
            }

            index = line.Length - 1;
            var windowSize = 1;
            while(lastNumber == null)
            {
                if (int.TryParse(line[index].ToString(), out var digit))
                {
                    lastNumber = digit;
                }

                var section = string.Concat(line.TakeLast(windowSize));
                if(numberDictionary.Any(x => section.Contains(x.Key)))
                {
                    lastNumber = numberDictionary.Where(x => section.Contains(x.Key)).First().Value;
                }

                windowSize++;
                index--;
            }

            return (int) (firstNumber + lastNumber);
        }
    }
}
