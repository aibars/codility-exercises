using System;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution(151);
        }

        public static int Solution(int N)
        {

            var binaryArray = Convert.ToString(N, 2).ToCharArray();

            var binaryPositions = new System.Collections.Generic.List<int> {
                0
            };
            for (var i = 1; i < binaryArray.Length; i++)
            {
                if (binaryArray[i] == '1')
                {
                    binaryPositions.Add(i);
                }
            }

            var differences = new System.Collections.Generic.List<int>();
            if(binaryPositions.Count == 1) return 0;
            for (var j = 1; j < binaryPositions.Count; j++)
            {
                differences.Add(binaryPositions[j] - binaryPositions[j - 1] - 1);
            }

            int maxDiff = -1;

            for (var i = 0; i < differences.Count; i++)
            {
                if (differences[i] > maxDiff) maxDiff = differences[i];
            }

            Console.Write(maxDiff);
            Console.ReadKey();
            return maxDiff;
        }
    }
}
