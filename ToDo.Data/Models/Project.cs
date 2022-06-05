using ToDo.Data.Models.Common;

namespace ToDo.Data.Models;

public class Project : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public string UserId { get; private set; }
    public virtual User User { get; set; }

    public Project(){}

    public Project(string name, string description, string userId)
    {
        Name = name;
        Description = description;
        UserId = userId;
    }
}