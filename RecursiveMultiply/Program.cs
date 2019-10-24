using System;

namespace RecursiveMultiply
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solution(2, 3));
            Console.WriteLine(solution(7, 3));
            Console.WriteLine(solution(3, 7));
            Console.WriteLine(solution(4, 1));
            Console.WriteLine(solution(3, 3));
            Console.WriteLine(solution(4, 4));
            Console.WriteLine(solution(5, 5));
            Console.WriteLine(solution(99, 5));
            Console.ReadKey();
        }

        /// <summary>
        /// Multiply two positive integers without using * operator
        /// </summary>
        static int solution(int a, int b)
        {
            if (b == 1) return a;

            return a + solution(a, b - 1);
        }
    }
}
