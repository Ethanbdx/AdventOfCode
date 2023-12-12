namespace AdventOfCodeCSharp.Day4 
{
    public static class Day4Solution 
    {
        public static int SolvePart1() 
        {
            int sumOfPoints = 0;
            var streamReader = new StreamReader("./Day4/Day4Input.txt");
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                var cardItems = line.Split(':');
                var numbers = cardItems[1].Split('|');
                var winningNumbers = numbers[0]
                                        .Trim()
                                        .Split(' ')
                                        .Where(x => !string.IsNullOrWhiteSpace(x))
                                        .ToHashSet();

                var cardPoints = numbers[1]
                                        .Trim()
                                        .Split(' ')
                                        .Where(x => winningNumbers.Contains(x))
                                        .Aggregate(0, (sum, val) => sum == 0 ? 1 : sum * 2);

                sumOfPoints += cardPoints;
            }

            return sumOfPoints;
        }
    }
}