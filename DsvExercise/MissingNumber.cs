namespace DsvExercise
{
    public class MissingOpenInterval
    {
        public MissingOpenInterval(int start, int end)
        {
            Start = start;
            End = end;
            Difference = end - start;
        }

        public int Start { get; set; }
        public int End { get; set; }
        public int Difference { get; private set; }
    }

    public static class MissingNumber
    {
        /*
         * Problem 1: Find the Missing Number
         * Write a C# function to find the missing number in an array of consecutive integers.
         * int[] arr = { 1, 2, 3, 5, 6, 7, 8 };
         * Result : 4
        */
        public static int FindMissingNumber(int[] input)
        {
            if (input == null) { return default; }
            if (input.Length == 0) { return default; }

            var numbersList = input.ToList();
            int missingNumber = default;

            numbersList.Sort();

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (numbersList[i + 1] - numbersList[i] > 1)
                {
                    missingNumber = numbersList[i] + 1;
                    break;
                }
            }

            return missingNumber;
        }

        /*
         * This is an improvement of the previous method. This will find all missing intervals within the integer array.
         */
        public static List<MissingOpenInterval> FindMissingIntervals(int[] input)
        {
            var missingIntervals = new List<MissingOpenInterval>();

            if (input == null) { return missingIntervals; }
            if (input.Length == 0) { return missingIntervals; }

            var numbersList = input.ToList();

            numbersList.Sort();

            for (int i = 0; i < numbersList.Count-1; i++)
            {
                if (numbersList[i + 1] - numbersList[i] > 1)
                {
                    missingIntervals.Add(new MissingOpenInterval(numbersList[i], numbersList[i+1]));
                }
            }

            return missingIntervals;
        }
    }
}
