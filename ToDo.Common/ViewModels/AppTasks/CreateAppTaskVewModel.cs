using System.ComponentModel.DataAnnotations;
using ToDo.Common.Enums;

namespace ToDo.Common.ViewModels.AppTasks;

public class CreateAppTaskVewModel
{
    [Required]
    public string Title { get; set; }
    public string SourceUserId { get; set; }
    public string TargetUserId { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DeadlineDate { get; set; }
}