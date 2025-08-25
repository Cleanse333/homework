// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Koko Ebanoidze");
        Console.Write("Enter your name: ");
        string name = Console.ReadLine(); 
        Console.WriteLine("Hello, " + name + "!");
    }
}


