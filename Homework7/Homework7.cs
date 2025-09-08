using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp23
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // homework N1
            Console.WriteLine("Input radius of the circle");
            var radius = Convert.ToInt32(Console.ReadLine());
            var Square1 = radius * 2;
            var Square2 = Math.Sqrt((Math.Pow(radius + radius, 2) / 2));
            var Square1area = Square1 * Square1;
            var Square2area = Square2 * Square2;
            var differenceInSize = Square1area - Square2area;
            Console.WriteLine(differenceInSize);

            // homework N2
            Console.WriteLine("enter amount of elements");
            int a = Convert.ToInt32(Console.ReadLine());
            char[] array = new char[a];
            Console.WriteLine("enter characters that you got");
            for (int i = 0; i < a; i++)
            {
                array[i] = Convert.ToChar(Console.ReadLine());
            }
            bool allequal = array.All(x => x == array[0]);
            if (allequal)
            {
                Console.WriteLine("Congratulations u won the jackpot");
            }
            else
            {
                Console.WriteLine("U failed to win");
            }

            // homework N3
            Console.WriteLine("enter how many wins your team has gotten");
            var wins = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter how many loses your team has gotten");
            var loses = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter how many draws your team has gotten");
            var draws = Convert.ToInt32(Console.ReadLine());
            var points = (wins * 3) + (loses * 0) + (draws * 1);
            Console.WriteLine($"Your team earned {points} points");


            // homework N4
            int[] workhours = new int[7];
            Console.WriteLine("Enter your work schedule");
            for (int i = 0; i < 7; i++)
            {
                workhours[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[] weekdays = workhours.Take(5).ToArray();
            int[] weekend = workhours.Skip(workhours.Length - 2).ToArray();

            int sum = 0;

            foreach (var x in weekdays)
            {
                if (x <= 8)
                {
                    sum += x * 10;
                }
                else
                {
                    sum += (8 * 10 + (x - 8) * 15);
                }
            }

            foreach (var y in weekend)
            {
                sum += y * 20;
            }

            Console.WriteLine($"you earned {sum}$ this week");


            //homework 5

            Console.WriteLine("enter number of days");

            var b = Convert.ToInt32(Console.ReadLine());
            int[] schedule = new int[b];
            Console.WriteLine("enter schedule");
            for (int x = 0; x < b; x++)
            {
                schedule[x] = Convert.ToInt32(Console.ReadLine());
            }


            int progresscount = 0;

            for (int y = 1; y < b; y++)
            {
                if (schedule[y] >= schedule[y - 1])
                {
                    progresscount++;
                }

            }

            Console.WriteLine(progresscount);


            //homework 6
            Console.WriteLine("enter amount of words");
            var z = Convert.ToInt32(Console.ReadLine());
            string[] words = new string[z];
            Console.WriteLine("enter words");
            for (int y = 0; y < z; y++)
            {
                words[y] = Console.ReadLine();
            }
            Console.WriteLine("enter length of words that u want to see");
            var length = Convert.ToInt32(Console.ReadLine());

            List<string> chosenwords = new List<string>();

            foreach (var word in words)
            {
                if (word.Length == length)
                {
                    chosenwords.Add(word);
                }
            }

            int counts = 1;

            foreach (var chosenword in chosenwords)
            {
                Console.WriteLine($"chosenword number-{counts} = {chosenword}");
                counts++;
            }

        }
    }


}
