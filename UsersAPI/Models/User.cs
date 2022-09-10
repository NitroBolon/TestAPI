namespace UsersAPI.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public DateTime BirthDate { get; set; }

        public List<UserProperty> UserProperties { get; set; }
    }
}