using System.ComponentModel.DataAnnotations;
using ToDo.Common.Enums;

namespace ToDo.Common.ViewModels.AppTasks;

public class CreateAppTaskVewModel
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string SourceUserEmail { get; set; }
    [Required]
    public string TargetUserId { get; set; }
    public string Description { get; set; }
    public long ProjectId { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DeadlineDate { get; set; }
}