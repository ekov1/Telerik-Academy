using System;
using System.Collections.Generic;
using System.Linq;
using _09.Students_tasks9to16;

namespace _18.GroupsTasks18And19
{
    class Groups
    {
        static void Main()
        {
            #region
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
            #endregion

            var groupedSubjectsLambda = subjectsList.GroupBy(x => x.Group.GroupNumber,
    (group, subjects) => new { Group = group, Subjects = subjects });

            var groupedSubjectsLINQ = from subject in subjectsList
                                      group subject by subject.Group.GroupNumber
                                          into groups
                                          select new
                                          {
                                              Group = groups.Key,
                                              Subjects = groups.ToList()
                                          };

            foreach (var subject in groupedSubjectsLINQ)
            {
                Console.WriteLine("\n-------------------- Group: " + subject.Group + " --------------------\n" + "Subjects in the group:\n\n" + string.Join("\n\n", subject.Subjects));
            }



        }
    }
}
