using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPI.Models
{
    public class UserPropertyDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Key { get; set; }
        public string? ValueString { get; set; }
        public long ValueInt { get; set; }
        public DateTime ValueDateTime { get; set; }
    }

    public class UserProperty : UserPropertyDto
    {
        public User User { get; set; }
    }
}
