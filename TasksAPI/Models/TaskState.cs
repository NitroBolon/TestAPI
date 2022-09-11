using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasksAPI.Models
{
    public class TaskStatePostDto
    {
        public long TenantId { get; set; }
        public int TenantOrder { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class TaskStateDto : TaskStatePostDto
    {

    }

    public class TaskState : TaskStateDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
    }
}
