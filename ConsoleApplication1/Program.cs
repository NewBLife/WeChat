using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            var grades = new List<Grade>();
            for (int j = 0; j < 10; j++)
            {
                var stus = new List<Student>();
                for (var i = 0; i < 10; i++)
                {
                    var stu = new Student
                    {
                        Id = i,
                        Name = "Name" + i.ToString("C2"),
                        GradeId = j,
                        Age = (new Random()).Next(10, 50),
                        Ints = new[] { 3, 5, 7 }
                    };
                    stus.Add(stu);
                }
                var grade = new Grade
                {
                    Id = j,
                    GradeName = "GradeName" + j.ToString("C2"),
                    Students = stus
                };
                grades.Add(grade);

            }
            var response = new ResponseEntity<List<Grade>>
            {
                Data = grades,
                ErrorCode = "S001",
                ErrorMsg = "Error is nothings."
            };
            var xml = response.ToXml(false);
            Console.WriteLine(xml);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
