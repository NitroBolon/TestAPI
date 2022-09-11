using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TasksAPI.Enums;

namespace TasksAPI.Models
{
    public class TaskPostDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AssigneeId { get; set; }
        public TaskPriority? Priority { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TaskType? Type { get; set; }
    }

    public class TaskDto : TaskPostDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string? Id { get; set; }
        public TaskState? State { get; set; }
        public Task? Parent { get; set; }
        public long TenantId { get; set; }
    }

    public class Task : TaskDto
    {

    }
}
