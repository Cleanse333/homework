using System;

namespace Homework8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            exercise1(25, 100, 2);
            exercise2("AAABBCC");
            exercise3("111111111111111111111", "333333333331111111");
            List<string> strings = new List<string> { "test", "random", "programming", "word" };
            exercise4(strings);
            exercise5(1234);
            exercise6([1, 2, 3, 4, 5, 1]);
        }



        //hw1 
        static void exercise1(int a, int b, double n)
        {
            var an = Math.Pow(a, 1 / n);
            var bn = Math.Pow(b, 1 / n);


            if (an > bn)
            {
                for (var i = bn + 1; i < an; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else if (an < bn)
            {
                for (var k = an + 1; k < bn; k++)
                {
                    Console.WriteLine(k);
                }
            }
            else if (an == bn)
            {
                Console.WriteLine("numbers are equal");
            }
        }



        //hw2
        static void exercise2(string socks)
        {
            socks.ToUpper();
            char[] chars = socks.ToCharArray();
            Array.Sort(chars);
            var pairs = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    pairs++;
                    i++;
                }
            }

            Console.WriteLine($"{pairs} - this many pairs");

        }


        //hw3
        static void exercise3(string word1, string word2)
        {
            List<string> saerto = new List<string>();
            if (word1.Length > word2.Length)
            {
                for (int i = word2.Length - 1; i >= 0; i--)
                {
                    if (word2[i] == word1[i + (word1.Length - word2.Length)])
                    {
                        saerto.Add(Convert.ToString(word2[i]));
                    }
                }
            }
            else
            {
                for (int i = word1.Length - 1; i >= 0; i--)
                {
                    if (word1[i] == word2[i + (word2.Length - word1.Length)])
                    {
                        saerto.Add(Convert.ToString(word1[i]));
                    }
                }
            }

            string result = string.Join("", saerto);
            char[] chars = result.ToCharArray();
            Array.Reverse(chars);
            string finalresult = new string(chars);
            Console.WriteLine(finalresult);
        }



        //hw4 
        static void exercise4<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("this list is empty");
            }

            Type type = typeof(T);

            if (type == typeof(string))
            {
                foreach (var item in list.Cast<string>())
                {
                    Console.WriteLine(item.ToUpper());
                }
            }
            else if (type == typeof(int))
            {
                var sum = 0;
                foreach (var item in list)
                {
                    sum += Convert.ToInt32(item);
                }
                Console.WriteLine(sum);
            }
            else if (type == typeof(bool))
            {
                var boolList = list.Cast<bool>().ToList();
                int midIndex = boolList.Count / 2;
                Console.WriteLine("First Element is " + boolList.First());
                Console.WriteLine("Last Element is " + boolList.Last());
                Console.WriteLine("Middle Element is " + boolList[midIndex]);
            }
            else
            {
                Console.WriteLine("this type is not supported");
            }
        }

        static void exercise5(int a)
        {
            if (a == 0)
            {
                return;
            }

            exercise5(a / 10);

            Console.Write(a % 10);
            Console.Write("-");


        }

        static void exercise6(int[] array)
        {
            int containsduplicate = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int k = 0; k < array.Length; k++)
                {
                    if (array[i] == array[k])
                    {
                        containsduplicate++;
                    }
                }
            }
            if(containsduplicate > array.Length)
            {
                Console.WriteLine();
                Console.WriteLine("True");
            }else
            {
                Console.WriteLine();
                Console.WriteLine("False");
            }
        }


    }
}
