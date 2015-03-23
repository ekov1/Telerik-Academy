using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StudentsAndWorkers
{
    class Test
    {
        static void Main()
        {
            List<Student> studentList = new List<Student>
            {
                new Student("Pesho", "Kolev", 11),
                new Student("Kolyo", "Totev", 10),
                new Student("Jivko", "Dimitrov", 11),
                new Student("Ivan", "Totev", 10),
                new Student("Pedro", "Pascal", 12),
                new Student("Lena", "Headey", 12),
                new Student("Dingo", "Jones", 11),
                new Student("Son", "Dayum", 9),
                new Student("Justin", "Dimitrov", 9),
                new Student("Lyubo", "Geshev", 12)
            };

            var sortedByGrade = studentList.OrderBy(x => x.Grade);

            List<Worker> workerList = new List<Worker>
            {
                new Worker("Djenko", "Saykov", 190, 8),
                new Worker("Silvia", "Zheleva", 280, 6),
                new Worker("Ivett", "Savova", 330, 9.5),
                new Worker("Sevda", "Voinova", 190, 4),
                new Worker("Maria", "Koseva", 640, 10),
                new Worker("Ivo", "Kenov", 520, 12),
                new Worker("Zhivko", "Zdravkov", 220, 7),
                new Worker("Toma", "Marinov", 100, 4),
                new Worker("Vasilena", "Georgieva", 420, 12),
                new Worker("Ivan", "Dobrev", 190, 8)
            };

            var sortedByMoneyPerHour = workerList.OrderByDescending(x => x.MoneyPerHour());

            var mergedList = new List<Human>();

            foreach (var item in sortedByGrade)
            {
                mergedList.Add(item);
            }

            foreach (var item in sortedByMoneyPerHour)
            {
                mergedList.Add(item);
            }

            var finalSortedList = mergedList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            foreach (var item in finalSortedList)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

        }
    }
}
