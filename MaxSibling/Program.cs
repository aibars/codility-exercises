using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaxSibling
{
    static class Program
    {
        static void Main(string[] args)
        {
            int n = 2147483647;
            Console.WriteLine(solution(n));
        }

        public static int solution(int n)
        {
            if (n < 0 && n > 2147483647) return -1;

            var arr = DigitToArray(n);

            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            var result = long.Parse(string.Join(string.Empty, arr));
            if (result > 100000000) return -1;
            return (int)result;
        }

        public static int NumDigits(int n)
        {
            if (n < 10) return 1;
            if (n < 100) return 2;
            if (n < 1000) return 3;
            if (n < 10000) return 4;
            if (n < 100000) return 5;
            if (n < 1000000) return 6;
            if (n < 10000000) return 7;
            if (n < 100000000) return 8;
            if (n < 1000000000) return 9;
            return 10;
        }

        public static int[] DigitToArray(int n)
        {
            var result = new int[NumDigits(n)];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = n % 10;
                n /= 10;
            }
            return result;
        }


    }
}