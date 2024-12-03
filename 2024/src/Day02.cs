using System.Diagnostics;

namespace src
{
    public class Day02
    {
        public static bool IsSafe(string input)
        {
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
                    Console.WriteLine("Returning false due to no difference");
                    return false;
                }
                // Unsafe if the difference is ever greater than 3
                if(Math.Abs(difference) > 3)
                {
                    Console.WriteLine("Returning false due to difference greater than 3");
                    return false;
                }

                // Set the increasing flag if it has not been set
                if(isIncreasing && increasing == null) {
                    // Console.WriteLine("Setting increasing to true");
                    increasing = true;
                }
                else if(!isIncreasing && increasing == null) {
                    // Console.WriteLine("Setting increasing to false");
                    increasing = false;
                }

                // If we are not always decreasing
                if (isIncreasing && increasing != null && increasing == false)
                {
                    Console.WriteLine("Returning false due to not always decreasing");
                    return false;
                }

                // If we are not always increasing
                if (!isIncreasing && increasing != null && increasing == true)
                {
                    Console.WriteLine("Returning false due to not always increasing");
                    return false;
                }
            }

            Console.WriteLine("Returning true");
            return true;
        }

        private static int[] ParseInput(string input)
        {
            return input.Split(" ").Select(i => Int32.Parse(i)).ToArray();
        }

        public static int CountSafe(string input)
        {
            return input.Split("\n").Select(line => IsSafe(line) ? 1 : 0).Sum();
        }
    }
}
