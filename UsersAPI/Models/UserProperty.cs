namespace UsersAPI.Models
{
    public class UserProperty
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Key { get; set; }
        public string? ValueString { get; set; }
        public long ValueInt { get; set; }
        public DateTime ValueDateTime { get; set; }

        public User User { get; set; }
    }
}
