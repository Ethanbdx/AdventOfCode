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
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                lines.Add(line);
            }

            //Loop through and determine if current position is a number
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    var currentChar = lines[i][j];
                    if (char.IsDigit(currentChar))
                    {
                        bool isPartNumber = false;
                        var numberBuilder = new StringBuilder();
                        //Realize the entire number by seeking right until there is no longer a number
                        while (isValidPos(i, j, lines.Count, lines[i].Length) && char.IsDigit(lines[i][j]))
                        {
                            numberBuilder.Append(lines[i][j]);
                            if (!isPartNumber)
                            {
                                isPartNumber = isAnySpecialCharAdjacent(i, j, lines);
                            }
                            j++;
                        }

                        if (isPartNumber)
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
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                lines.Add(line);
            }

            var starPositions = new List<Tuple<int, int>>();

            //Loop through and determine if current position is a '*'
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '*')
                    {
                        var adjNumbers = findAllAdjacentNumbers(i, j, lines);
                        if (adjNumbers.Count == 2)
                        {
                            Console.WriteLine($"Found {adjNumbers.Count} numbers adjacent to * at row: {i}, column {j}");
                            foreach(var num in adjNumbers) 
                            {
                                Console.WriteLine($"Number Found: {num}");
                            }
                            gearRatioSum += adjNumbers[0] * adjNumbers[1];
                        }
                    }
                }
            }

            return gearRatioSum;
        }

        private static bool isValidPos(int i, int j, int n, int m)
        {
            if (i < 0 || j < 0 || i > n - 1 || j > m - 1)
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
            if (isValidPos(i - 1, j, n, m))
            {
                var characterAtPos = arr[i - 1][j];
                if (!char.IsDigit(characterAtPos) && characterAtPos != '.')
                {
                    return true;
                }
            }
            //check down
            if (isValidPos(i + 1, j, n, m))
            {
                var characterAtPos = arr[i + 1][j];
                if (!char.IsDigit(characterAtPos) && characterAtPos != '.')
                {
                    return true;
                }
            }
            //check left
            if (isValidPos(i, j - 1, n, m))
            {
                var characterAtPos = arr[i][j - 1];
                if (!char.IsDigit(characterAtPos) && characterAtPos != '.')
                {
                    return true;
                }
            }
            //check right
            if (isValidPos(i, j + 1, n, m))
            {
                var characterAtPos = arr[i][j + 1];
                if (!char.IsDigit(characterAtPos) && characterAtPos != '.')
                {
                    return true;
                }
            }
            //check up/left
            if (isValidPos(i - 1, j - 1, n, m))
            {
                var characterAtPos = arr[i - 1][j - 1];
                if (!char.IsDigit(characterAtPos) && characterAtPos != '.')
                {
                    return true;
                }
            }
            //check up/right
            if (isValidPos(i - 1, j + 1, n, m))
            {
                var characterAtPos = arr[i - 1][j + 1];
                if (!char.IsDigit(characterAtPos) && characterAtPos != '.')
                {
                    return true;
                }
            }
            //check down/left
            if (isValidPos(i + 1, j - 1, n, m))
            {
                var characterAtPos = arr[i + 1][j - 1];
                if (!char.IsDigit(characterAtPos) && characterAtPos != '.')
                {
                    return true;
                }
            }
            //check down/right
            if (isValidPos(i + 1, j + 1, n, m))
            {
                var characterAtPos = arr[i + 1][j + 1];
                if (!char.IsDigit(characterAtPos) && characterAtPos != '.')
                {
                    return true;
                }
            }

            return false;
        }

        private static List<int> findAllAdjacentNumbers(int i, int j, List<string> arr)
        {
            var adjNumbers = new List<int>();

            var n = arr.Count;
            var m = arr[0].Length;
            //check up
            //if up is a digit, up/left & right cannot be numbers
            if (isValidPos(i - 1, j, n, m))
            {
                var currentPos = arr[i - 1][j];
                if (char.IsDigit(currentPos))
                {
                    var numberBuilder = new List<char>();
                    int seekLeft = j - 1;
                    int seekRight = j + 1;
                    while(isValidPos(i - 1, seekLeft, n, m) && char.IsDigit(arr[i - 1][seekLeft])) 
                    {
                        numberBuilder.Add(arr[i - 1][seekLeft]);
                        seekLeft--;
                    }
                    numberBuilder.Reverse();
                    numberBuilder.Add(arr[i - 1][j]);
                    while(isValidPos(i - 1, seekRight, n, m) && char.IsDigit(arr[i - 1][seekRight])) 
                    {
                        numberBuilder.Add(arr[i - 1][seekRight]);
                        seekRight++;
                    }

                    adjNumbers.Add(int.Parse(string.Concat(numberBuilder)));
                }
                else 
                {
                    //Diag left
                    if (isValidPos(i - 1, j - 1, n, m) && char.IsDigit(arr[i - 1][j - 1])) 
                    {
                        var numberBuilder = new StringBuilder();
                        numberBuilder.Append(arr[i - 1][j - 1]);
                        int seek = j - 2;
                        //seek left then reverse
                        while(isValidPos(i - 1, seek, n, m) && char.IsDigit(arr[i - 1][seek])) 
                        {
                            numberBuilder.Append(arr[i - 1][seek]);
                            seek--;
                        }
                        adjNumbers.Add(int.Parse(string.Concat(numberBuilder.ToString().Reverse())));
                    }

                    //Diag right
                    if (isValidPos(i - 1, j + 1, n, m) && char.IsDigit(arr[i - 1][j + 1])) 
                    {
                        var numberBuilder = new StringBuilder();
                        numberBuilder.Append(arr[i - 1][j + 1]);
                        int seek = j + 2;
                        while(isValidPos(i - 1, seek, n, m) && char.IsDigit(arr[i - 1][seek])) 
                        {
                            numberBuilder.Append(arr[i - 1][seek]);
                            seek++;
                        }

                        adjNumbers.Add(int.Parse(numberBuilder.ToString()));
                    }
                }
            }
        
            //check left
            if(isValidPos(i, j - 1, n, m)) 
            {
                var currentPos = arr[i][j - 1];
                //seek left until not digit and reverse
                if(char.IsDigit(currentPos)) 
                {
                    var numberBuilder = new List<char> 
                    {
                        currentPos
                    };
                    int seek = j - 2;
                    while(isValidPos(i, seek, n, m) && char.IsDigit(arr[i][seek])) 
                    {
                        numberBuilder.Add(arr[i][seek]);
                        seek--;
                    }
                    numberBuilder.Reverse();
                    adjNumbers.Add(int.Parse(string.Concat(numberBuilder)));
                }
            }

            //check right
            if(isValidPos(i, j + 1, n, m)) 
            {
                var currentPos = arr[i][j + 1];
                //seek right until not digit
                if(char.IsDigit(currentPos)) 
                {
                    var numberBuilder = new List<char> 
                    {
                        currentPos
                    };
                    int seek = j + 2;
                    while(isValidPos(i, seek, n, m) && char.IsDigit(arr[i][seek])) 
                    {
                        numberBuilder.Add(arr[i][seek]);
                        seek++;
                    }
                    adjNumbers.Add(int.Parse(string.Concat(numberBuilder)));
                }
            }

            //check down and diags
            if (isValidPos(i + 1, j, n, m))
            {
                var currentPos = arr[i + 1][j];
                if (char.IsDigit(currentPos))
                {
                    var numberBuilder = new List<char>();
                    int seekLeft = j - 1;
                    int seekRight = j + 1;
                    while(isValidPos(i + 1, seekLeft, n, m) && char.IsDigit(arr[i + 1][seekLeft])) 
                    {
                        numberBuilder.Add(arr[i + 1][seekLeft]);
                        seekLeft--;
                    }
                    numberBuilder.Reverse();
                    numberBuilder.Add(arr[i + 1][j]);
                    while(isValidPos(i + 1, seekRight, n, m) && char.IsDigit(arr[i + 1][seekRight])) 
                    {
                        numberBuilder.Add(arr[i + 1][seekRight]);
                        seekRight++;
                    }

                    adjNumbers.Add(int.Parse(string.Concat(numberBuilder)));
                }
                else 
                {
                    //Diag left
                    if (isValidPos(i + 1, j - 1, n, m) && char.IsDigit(arr[i + 1][j - 1])) 
                    {
                        var numberBuilder = new StringBuilder();
                        numberBuilder.Append(arr[i + 1][j - 1]);
                        int seek = j - 2;
                        //seek left then reverse
                        while(isValidPos(i + 1, seek, n, m) && char.IsDigit(arr[i + 1][seek])) 
                        {
                            numberBuilder.Append(arr[i + 1][seek]);
                            seek--;
                        }
                        adjNumbers.Add(int.Parse(string.Concat(numberBuilder.ToString().Reverse())));
                    }

                    //Diag right
                    if (isValidPos(i + 1, j + 1, n, m) && char.IsDigit(arr[i + 1][j + 1])) 
                    {
                        var numberBuilder = new StringBuilder();
                        numberBuilder.Append(arr[i + 1][j + 1]);
                        int seek = j + 2;
                        while(isValidPos(i + 1, seek, n, m) && char.IsDigit(arr[i + 1][seek])) 
                        {
                            numberBuilder.Append(arr[i + 1][seek]);
                            seek++;
                        }

                        adjNumbers.Add(int.Parse(numberBuilder.ToString()));
                    }
                }
            }

            return adjNumbers;
        }
    }
}

