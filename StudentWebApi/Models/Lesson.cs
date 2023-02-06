namespace StudentWebApi.Models
{
    // Lesson model
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int SessionDayOfWeek { get; set; }
    }


    //Lesson list
    public class LessonService : ILesson
    {
        public List<Lesson> GetLesson()
        {
            var lessons = new List<Lesson>()
            {
                new Lesson()
                {
                    Id = 1,
                    Name = "Science",
                    Capacity = 10,
                    SessionDayOfWeek = (int)DayOfWeek.Monday
                },
                new Lesson()
                {
                    Id = 2,
                    Name = ".Net",
                    Capacity = 5,
                    SessionDayOfWeek = (int)DayOfWeek.Monday
                }
            };
            return lessons;
        }
    }
}
