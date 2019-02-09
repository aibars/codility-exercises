using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution(new int[] { 1, 22, 101, -14 });
        }

        public static int Solution(int[] A)
        {
            int sum = 0;

            if (A == null && A.Length == 0) { return 0; }

            for (int i = 0; i < A.Length; i++)
            {
                decimal dividedInt = Math.Abs(A[i] / 10m);
                if (dividedInt >= 1 & dividedInt < 10) { sum += A[i]; }
            }

            return sum;
        }
    }
}
