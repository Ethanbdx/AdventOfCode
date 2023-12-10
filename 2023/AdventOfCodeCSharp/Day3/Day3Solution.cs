using System.Text;

namespace AdventOfCodeCSharp.Day3 
{
    public static class Day3Solution 
    {
        public static int SolvePart1() 
        {
            int partNumberSum = 0;
            //Parse the input from txt file
            var streamReader = new StreamReader("./Day3/Day3Input.txt");
            var lines = new List<string>();
            while(!streamReader.EndOfStream) 
            {
                var line = streamReader.ReadLine();
                lines.Add(line);
            }

            //Loop through and determine if current position is a number
            for(int i = 0; i < lines.Count; i++) 
            {
                for(int j = 0; j < lines[i].Length; j++) 
                {
                    var currentChar = lines[i][j];
                    if(char.IsDigit(currentChar))
                    {
                        bool isPartNumber = false;
                        var numberBuilder = new StringBuilder();
                        //Realize the entire number by seeking right until there is no longer a number
                        while(isValidPos(i, j, lines.Count, lines[i].Length) && char.IsDigit(lines[i][j])) 
                        {
                            numberBuilder.Append(lines[i][j]);
                            if(!isPartNumber) 
                            {
                                isPartNumber = isAnySpecialCharAdjacent(i, j, lines);
                            }  
                            j++;
                        }

                        if(isPartNumber) 
                        {
                            partNumberSum += int.Parse(numberBuilder.ToString());
                        }
                    }
                }
            }

            return partNumberSum;
        }

        public static int SolvePart2() 
        {
            int gearRatioSum = 0;
            //Parse the input from txt file
            var streamReader = new StreamReader("./Day3/Day3Input.txt");
            var lines = new List<string>();
            while(!streamReader.EndOfStream) 
            {
                var line = streamReader.ReadLine();
                lines.Add(line);
            }
            
            var starPositions = new List<Tuple<int, int>>();

            //Loop through and determine if current position is a '*'
            for(int i = 0; i < lines.Count; i++) 
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    if(lines[i][j] == '*') 
                    {
                        starPositions.Add(new(i, j));
                    }
                }
            }

            
            //If it is, c
            return gearRatioSum;
        }

        private static bool isValidPos(int i, int j, int n, int m) 
        {
            if(i < 0 || j < 0 || i > n - 1 || j > m - 1)
            {
                return false;
            }

            return true;
        }

        private static bool isAnySpecialCharAdjacent(int i, int j, List<string> arr) 
        {
            var n = arr.Count;
            var m = arr[i].Length;
            //check up
            if(isValidPos(i - 1, j, n, m)) 
            {
                var characterAtPos = arr[i - 1][j];
                if(!char.IsDigit(characterAtPos) && characterAtPos != '.') 
                {
                    return true;
                }
            }
            //check down
            if(isValidPos(i + 1, j, n, m)) 
            {
                var characterAtPos = arr[i + 1][j];
                if(!char.IsDigit(characterAtPos) && characterAtPos != '.') 
                {
                    return true;
                }
            }
            //check left
            if(isValidPos(i, j - 1, n, m)) 
            {
                var characterAtPos = arr[i][j - 1];
                if(!char.IsDigit(characterAtPos) && characterAtPos != '.') 
                {
                    return true;
                }
            }
            //check right
            if(isValidPos(i, j + 1, n, m)) 
            {
                var characterAtPos = arr[i][j + 1];
                if(!char.IsDigit(characterAtPos) && characterAtPos != '.') 
                {
                    return true;
                }
            }
            //check up/left
            if(isValidPos(i - 1, j - 1, n, m)) 
            {
                var characterAtPos = arr[i - 1][j - 1];
                if(!char.IsDigit(characterAtPos) && characterAtPos != '.') 
                {
                    return true;
                }
            }
            //check up/right
            if(isValidPos(i - 1, j + 1, n, m)) 
            {
                var characterAtPos = arr[i - 1][j + 1];
                if(!char.IsDigit(characterAtPos) && characterAtPos != '.') 
                {
                    return true;
                }
            }
            //check down/left
            if(isValidPos(i + 1, j - 1, n, m)) 
            {
                var characterAtPos = arr[i + 1][j - 1];
                if(!char.IsDigit(characterAtPos) && characterAtPos != '.') 
                {
                    return true;
                }
            }
            //check down/right
            if(isValidPos(i + 1, j + 1, n, m)) 
            {
                var characterAtPos = arr[i + 1][j + 1];
                if(!char.IsDigit(characterAtPos) && characterAtPos != '.') 
                {
                    return true;
                }
            }

            return false;
        }
    }
}

