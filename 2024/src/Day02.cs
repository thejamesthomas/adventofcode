using System.Diagnostics;

namespace src
{
    public class Day02
    {
        public static bool IsSafeDampened(string input)
        {
            Debug.WriteLine($"IsSafeDampened - input:{input}");
            var readings = input.Split(" ").ToArray();
            for (int i = 0; i < readings.Length; i++)
            {
                Console.WriteLine(i);
                if (IsSafe(RemoveBadReading(input, i)))
                {
                    Debug.WriteLine($"Found Safe input by removing index {i}");
                    return true;
                }
            }

            Debug.WriteLine($"No safe input found for {input}");
            return false;
        }
        public static bool IsSafe(string input)
        {
            Debug.WriteLine($"IsSafe - input:{input}");
            bool? increasing = null;
            int[] numbers = ParseInput(input);

            for(int i = 0; i < numbers.Length - 1; i++)
            {
                var currentNumber = numbers[i];
                var nextNumber = numbers[i + 1];
                var difference = currentNumber - nextNumber;
                var isIncreasing = difference < 0;

                // If there is no difference it is unsafe
                if(difference == 0)
                {
                    Debug.WriteLine("Returning false due to no difference");
                    return false;
                }
                // Unsafe if the difference is ever greater than 3
                if(Math.Abs(difference) > 3)
                {
                    Debug.WriteLine("Returning false due to difference greater than 3");
                    return false;
                }

                // Set the increasing flag if it has not been set
                if(isIncreasing && increasing == null) {
                    // Console.WriteLine("Setting increasing to true");
                    increasing = true;
                    continue;
                }
                if(!isIncreasing && increasing == null) {
                    // Console.WriteLine("Setting increasing to false");
                    increasing = false;
                    continue;
                }

                // If we are not always decreasing
                if (isIncreasing && increasing != null && increasing == false)
                {
                    Debug.WriteLine("Returning false due to not always decreasing");
                    return false;
                }

                // If we are not always increasing
                if (!isIncreasing && increasing != null && increasing == true)
                {
                    Debug.WriteLine("Returning false due to not always increasing");
                    return false;
                }
            }

            Debug.WriteLine("Returning true");
            return true;
        }

        private static int[] ParseInput(string input)
        {
            return input.Split(" ").Select(i => Int32.Parse(i)).ToArray();
        }

        public static int CountSafe(string input, bool dampenerEnabled = false)
        {
            return input.Split("\n").Select(line => IsSafe(line) ? 1 : 0).Sum();
        }
        public static int CountSafeDampened(string input, bool dampenerEnabled = false)
        {
            return input.Split("\n").Select(line => IsSafeDampened(line) ? 1 : 0).Sum();
        }

        public static string RemoveBadReading(string input, int index)
        {
            Debug.WriteLine($"RemoveBadReading - input: {input}, index:{index}");
            var characters = input.Split(" ").ToList();
            characters.RemoveAt(index);
            return string.Join(" ", characters);
        }
    }
}
