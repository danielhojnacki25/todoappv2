using ToDo.Common.Enums;
using ToDo.Data.Models.Common;

namespace ToDo.Data.Models;

public class AppTask : Entity
{
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public Status Status { get; private set; }
    public DateTime CreationDate { get; init; }
    public DateTime DeadlineDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public Priority Priority { get; private set; }
    public long? ProjectId { get; private set; }
    public Project Project { get; set; }

    public string? TargetUserId { get; set; }
    public virtual User TargetUser { get; set; }
    public string? SourceUserId { get; set; }
    public virtual User SourceUser { get; set; }

    public AppTask(){}

    public AppTask(string title, string description, string targetUser, string sourceUser, Priority priority, DateTime deadlineDateTime)
    {
        Title = title;
        Description = description;
        TargetUserId = targetUser;
        SourceUserId = sourceUser;
        Status = Status.Active;
        Priority = priority;
        CreationDate = DateTime.Now;
        EndDate = DateTime.MinValue;
        DeadlineDate = deadlineDateTime;
    }

    public void SetProject(long projectId)
        => ProjectId = projectId;
}