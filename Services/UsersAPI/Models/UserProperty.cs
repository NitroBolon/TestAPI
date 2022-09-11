using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPI.Models
{
    public class UserPropertyPostDto
    {
        public string? UserId { get; set; }
        public string? Key { get; set; }
        public string? ValueString { get; set; }
        public long? ValueInt { get; set; }
        public bool? ValueBool { get; set; }
        public DateTime? ValueDateTime { get; set; }
    }

    public class UserPropertyDto : UserPropertyPostDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

    public class UserProperty : UserPropertyDto
    {
        public User User { get; set; }
    }
}
