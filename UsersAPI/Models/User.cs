using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPI.Models
{
    public class UserDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class User : UserDto
    {
        public List<UserProperty> UserProperties { get; set; }
    }
}