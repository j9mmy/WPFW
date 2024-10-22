namespace deez.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public User(string email)
        {
            Email = email;
        }
    }
}