namespace deez.Models
{
    public class Teacher : User
    {
        public int Id { get; set; }
        public string TeachingCourse { get; set; }
        public List<Student> Students { get; set; }

        public Teacher(string email, string teachingCourse) : base(email)
        {
            TeachingCourse = teachingCourse;
        }
    }
}