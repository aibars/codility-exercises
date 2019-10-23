using System;

namespace HammeredNails
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 1, 1, 3, 3, 3, 4, 5, 5, 5, 5 }, 2)); //should be 5
            Console.WriteLine(solution(new int[] { 1, 1, 3, 3 }, 2)); //should be 4
            Console.WriteLine(solution(new int[] { 1, 1, 3, 3 }, 1)); //should be 3
            Console.WriteLine(solution(new int[] { 1, 1, 1 }, 0)); //should be 0
            Console.WriteLine(solution(new int[] { 1, 2, 3 }, 1)); //should be 2
            Console.WriteLine(solution(new int[] { 1, 2, 3 }, 2)); //should be 3
            Console.WriteLine(solution(new int[] { 1, 5, 5, 5, 5 }, 2)); //should be 3
        }

        public static int solution(int[] A, int K)
        {
            int n = A.Length;
            int best = 0;
            int count = 1;

            for (int i = 0; i < n - 1; i++)
            {
                if (A[i] == A[i + 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }

                if (K > 0 && count > best && A[i] != A[n - 1])
                {
                    best = count;
                }
            }

            var result = best + K;

            return result;
        }
    }
}
