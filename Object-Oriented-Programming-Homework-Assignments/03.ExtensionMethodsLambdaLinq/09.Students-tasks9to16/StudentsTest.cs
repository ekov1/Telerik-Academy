using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Students_tasks9to16
{
    public class StudentsTest
    {
        static void Main()
        {
            TestSubjects();
        }

        public static void TestSubjects()
        {

            Student subject40201 = new Student("40201", "Yahwezsxw", "199912", "056-555-555-5544", "sj40201@martians.ms",
                new List<int> { 5, 4, 6, 2, 6, 3, 6, 3, 5, 2 }, new Group(2, "Biology"));
            Student subject36521 = new Student("36521", "Terrra", "199806", "02-555-555-5545", "sj36521@abv.bg",
                new List<int> { 2, 2, 5, 2, 2, 3, 4, 3, 5, 2 }, new Group(1, "Mathematics"));
            Student subject40202 = new Student("10820", "Anzyx", "199906", "056-555-555-5546", "sj40202-YOLO@martians.ms",
                new List<int> { 3, 2, 6, 4, 3, 2, 2, 6 }, new Group(1, "Physics"));
            Student subject26532 = new Student("26532", "Booyahwe", "196416", "02-555-555-5586", "SWAGGINS-sj26532@abv.bg",
                new List<int> { 2, 2, 4, 4, 4, 4, 3 }, new Group(1, "Physics"));
            Student subject63511 = new Student("63511", "Jexxer", "199877", "052-555-555-5591", "rebelliousSJ-511@martians.ms",
                new List<int> { 3, 2, 6, 4, 3, 2, 2, 6 }, new Group(2, "Biology"));
            Student subject52776 = new Student("52776", "Zond", "199914", "052-555-555-5522", "Zond776@abv.bg",
                new List<int> { 6, 6, 6, 2, 6, 6, 6, 5, 2 }, new Group(1, "Mathematics"));

            List<Student> subjectsList = new List<Student>
            {
                subject40201,
                subject36521,
                subject40202,
                subject26532,
                subject63511,
                subject52776
            };

            var subjectsGroupTwoLINQ = from subject in subjectsList
                                       where subject.Group.GroupNumber == 2
                                       orderby subject.FirstName
                                       select subject;

            var subjectsGroupTwoLambda = subjectsList.Where(x => x.Group.GroupNumber == 2).OrderBy(x => x.FirstName);

            Console.WriteLine("Subjects in group 2, sorted by their first name:\n");
            foreach (var subject in subjectsGroupTwoLambda)
            {
                Console.WriteLine(subject);
                Console.WriteLine(new string('*', 40));
            }


            string mailHost = "@abv.bg";

            var subjectsWithABVLINQ = from subject in subjectsList
                                      where subject.Email.Contains(mailHost)
                                      select subject;

            var subjectsWithABVLambda = subjectsList.Where(x => x.Email.Contains(mailHost));

            Console.WriteLine("\nAll students with emails registered at abv.bg\n");
            foreach (var subject in subjectsWithABVLambda)
            {
                Console.WriteLine(subject);
                Console.WriteLine(new string('*', 40));
            }

            string sofiaTelCode = "02";

            var subjectsWithTelSofiaLINQ = from subject in subjectsList
                                           where subject.Tel.StartsWith(sofiaTelCode)
                                           select subject;

            Console.WriteLine("\nAll students with phone numbers registered in Sofia\n");
            foreach (var subject in subjectsWithTelSofiaLINQ)
            {
                Console.WriteLine(subject);
                Console.WriteLine(new string('*', 40));
            }

            var anonSubjects = from subject in subjectsList
                               where subject.MarksList.Contains(6)
                               select new
                               {
                                   FullName = subject.FirstName + " " + subject.LastName,
                                   Marks = subject.MarksList
                               };

            Console.WriteLine("\nAll students with at least one mark of Excellence (6)\n");
            foreach (var subject in anonSubjects)
            {
                Console.WriteLine(subject.FullName);
            }

            var anonSubjectsWithTwos = subjectsList.Where(x => x.MarksList.FindAll(y => y == 2).Count == 2).
                Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    Marks = x.MarksList
                });

            Console.WriteLine("\nAll students with exactly two Fail (2) marks\n");
            foreach (var subject in anonSubjectsWithTwos)
            {
                Console.WriteLine(subject.FullName);
            }

            var subjectsFrom06 = subjectsList.Where(x => x.FN[4] == '0' && x.FN[5] == '6');
            var marksFrom06 = new List<int>();

            foreach (var subject in subjectsFrom06)
            {
                marksFrom06.AddRange(subject.MarksList);
            }

            Console.WriteLine("\nAll marks of subjects who enrolled in the year 2006:");
            Console.WriteLine(string.Join(", ", marksFrom06));
            Console.WriteLine();
            Console.WriteLine();


            var subjectsInMathDpt = subjectsList.Where(x => x.Group.Department == "Mathematics");
            Console.WriteLine("\nAll students in the Maths department:");
            Console.WriteLine(string.Join(", ", subjectsInMathDpt));

        }
    }
}
