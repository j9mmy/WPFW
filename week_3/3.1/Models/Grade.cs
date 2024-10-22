namespace deez.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public Grade(int value)
        {
            Value = value;
        }
    }
}