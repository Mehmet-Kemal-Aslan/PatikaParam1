using StudentWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApiUnitTests.TestSetup
{
    public static class Students
    {
        public static void AddStudents(this StudentDbContext context)
        {
            context.Students.AddRange(
            new Student
            {
                Id = 1,
                Name = "Mehmet Kemal",
                Surname = "Aslan",
                Grade = 6,
                Note = "Not",
                ProjectId = 1,
            },
            new Student
            {
                Id = 2,
                Name = "Arif Cemal",
                Surname = "Özcan",
                Grade = 9,
                Note = "Not",
                ProjectId = 1,
            },
            new Student
            {
                Id = 3,
                Name = "Sefa",
                Surname = "Çaksu",
                Grade = 10,
                Note = "Not",
                ProjectId = 1,
            });
        }
    }
}
