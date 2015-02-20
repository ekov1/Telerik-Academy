using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write methods that calculate the area of a triangle by given:
//Side and an altitude to it;
//Three sides;
//Two sides and an angle between them;
//Use System.Math.

    class Program
    {
        static void Main()
        {
            Console.Write("This program solves simple tasks like finding the min/max/average/sum or product of a sequence of numbers.\n");
            while (true)
            {
                Console.Write("Enter '1' to find the triangle's area for any side and its altitude;\nEnter '2' to find the triangle's area for any three sides;\nEnter '3' to find the triangle's area for any two sides and the angle between them;\nEnter 'quit' to exit program.\nChoice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": Console.WriteLine("Area of triangle: " + SideAltitudeArea()); break;
                    case "2": Console.WriteLine("Area of triangle: " + SidesArea()); break;
                    case "3": Console.WriteLine("Area of triangle: " + SidesAngle()); break;
                    case "quit": break;
                    default: Console.WriteLine("Invalid input!"); break;
                }
                Console.Write("\nPress a key to continue...");
                Console.ReadLine();
                if (choice == "quit")
                {
                    break;
                }
                Console.Clear();
            }

        }

        private static double SidesAngle()
        {
            Console.Write("Enter side 'a' length: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter side 'b' length: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter the angle Gamma: ");
            double x = double.Parse(Console.ReadLine());
            double area = Math.Sin(x*Math.PI/180) * a * b * 0.5;

            return area;
        }

        private static double SidesArea()
        {
            Console.Write("Enter side 'a' length: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter side 'b' length: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter side 'c' length: ");
            double c = double.Parse(Console.ReadLine());


            double area = (a + b + c) * 0.5;

            return area;
        }

        private static double SideAltitudeArea()
        {
            Console.Write("Enter your base length: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter the height: ");
            double h = double.Parse(Console.ReadLine());

            double area = b * h * 0.5;

            return area;
        }
    }
