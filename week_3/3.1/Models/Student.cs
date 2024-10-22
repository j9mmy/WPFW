namespace deez.Models
{
    public class Student : User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Grade> Grades { get; set; }

        public Student(string email, string name) : base(email)
        {
            Name = name;
        }
    }
}