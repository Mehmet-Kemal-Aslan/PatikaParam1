using StudentWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApiUnitTests.TestSetup
{
    public static class Mentors
    {
        public static void AddMentors(this StudentDbContext context)
        {
            context.Mentors.AddRange(
            new Mentor
            {
                Name = "Mentor1",
                Surname = "MentorSurname1",
                BirthDate = DateTime.Now,
                ProjectId = 1,
            },
            new Mentor
            {
                Name = "Mentor2",
                Surname = "MentorSurname2",
                BirthDate = DateTime.Now,
                ProjectId = 1,
            },
            new Mentor
            {
                Name = "Mentor3",
                Surname = "MentorSurname3",
                BirthDate = DateTime.Now,
                ProjectId = 1,
            });
        }
    }
}
