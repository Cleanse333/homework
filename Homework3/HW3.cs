namespace homework3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // hw1 
            Console.WriteLine("Input your number");
            var x = Convert.ToInt32(Console.ReadLine());
            if (x % 5 == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }


            // hw2
            Console.WriteLine("Input first number");
            var a = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("input second number");
            var b = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Input +  -  / or *");
            var character = Convert.ToChar(Console.ReadLine());
            decimal result = 0;

            if ((b == 0) && character == '/')
            {
                Console.WriteLine("u can not divide by 0");
            }
            else
            {
                switch (character)
                {
                    case '+':
                        result = a + b; break;

                    case '*':
                        result = a * b; break;

                    case '/':
                        if (a > b)
                        {
                            result = a / b;
                        }
                        else
                        {
                            result = b / a;
                        }
                        break;

                    case '-':
                        if (a > b)
                        {
                            result = a - b;
                        }
                        else
                        {
                            result = b - a;
                        }
                        break;
                    default:
                        result = 0;
                        break;
                }
                Console.WriteLine($"Result = {result}");
            }

            // hw3

            Console.WriteLine("input first number");
            var c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input second number");
            var z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{z} and {c}");


            // hw4 

            Console.WriteLine("input your number");
            var numb = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{numb} * {i} = {numb * i}");
            }


            // hw5 

            Console.WriteLine("input number");
            var n = Convert.ToInt32(Console.ReadLine());
            for( int i = 2; i < n+1; i+=2)
            {
                Console.WriteLine($"{i*i}");
            }





        }


    }
}

