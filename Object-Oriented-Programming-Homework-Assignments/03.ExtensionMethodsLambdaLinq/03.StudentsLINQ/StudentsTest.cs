using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.StudentsLINQ
{
    class StudentsTest
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("John", "Achles", 21));
            students.Add(new Student("Lindsey", "Stirling", 27));
            students.Add(new Student("Gavin", "Draham", 24));
            students.Add(new Student("Charlie", "Joe", 28));
            students.Add(new Student("Davey", "Nickson", 21));
            students.Add(new Student("Gerry", "Patterson", 15));

            Console.WriteLine("All students:");
            foreach (var student in students)
            {
                Console.WriteLine("{0} {1} Age: {2}", student.FirstName, student.LastName, student.Age);
            }

            var firstBeforeLastStudents = from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            Console.WriteLine("\nStudents' whose First Names come before their Last Names:");
            foreach (var student in firstBeforeLastStudents)
            {
                Console.WriteLine("{0} {1} Age: {2}", student.FirstName, student.LastName, student.Age);
            }

            var studentsAge = from student in students
                where student.Age >= 18
                where student.Age <= 24
                select student;

            Console.WriteLine("\nStudents' whose Age is between 18 and 24:");
            foreach (var student in studentsAge)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }

            var orderedStudentsLambda = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

            Console.WriteLine("\n(USING LAMBDA)Students' ordered in descending order by their First and Last names:");

            foreach (var student in orderedStudentsLambda)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }

            var orderedStudentsLinq = from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            Console.WriteLine("\n(USING LINQ)Students' ordered in descending order by their First and Last names:");

            foreach (var student in orderedStudentsLinq)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}
