using StudentWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApiUnitTests.TestSetup
{
    public static class Projects
    {
        public static void AddProjects(this StudentDbContext context)
        {
            context.Projects.AddRange(
            new Project
            {
                Name = "Proje1",
                IsActive = true,
            },
            new Project
            {
                Name = "Proje2",
                IsActive = true,
            },
            new Project
            {
                Name = "Proje3",
                IsActive = false,
            });
        }
    }
}
