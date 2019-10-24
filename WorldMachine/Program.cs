using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorldMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            string a = "13 DUP 4 POP 5 DUP + DUP + -";
            Console.WriteLine(solution(a));
        }

        public static int solution(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length >= 2000) return -1;

            var arr = s.Split(' ');

            var stack = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int result;
                var parseResult = int.TryParse(arr[i], out result);

                if (result < 0 && result > 1048575) return -1;
                if (parseResult)
                {
                    stack.Push(result);
                }
                else
                {
                    try
                    {
                        if (arr[i] == "DUP")
                        {
                            stack.Push(stack.Peek());
                        }
                        else if (arr[i] == "POP")
                        {
                            stack.Pop();
                        }
                        else if (arr[i] == "+")
                        {
                            var tempStack = new Stack<int>(stack.Reverse());
                            tempStack.Pop();
                            var sum = stack.Peek() + tempStack.Peek();
                            stack.Pop();
                            stack.Pop();
                            stack.Push(sum);
                        }
                        else if (arr[i] == "-")
                        {
                            var tempStack = new Stack<int>(stack.Reverse());
                            tempStack.Pop();
                            var diff = stack.Peek() - tempStack.Peek();
                            stack.Pop();
                            stack.Pop();
                            stack.Push(diff);
                        }
                        else return -1;
                    }
                    catch
                    {
                        return -1;
                    }
                }
            }

            return stack.Peek();
        }
    }
}
