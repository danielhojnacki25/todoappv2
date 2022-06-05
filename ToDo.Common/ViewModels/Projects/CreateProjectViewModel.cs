using System.ComponentModel.DataAnnotations;

namespace ToDo.Common.ViewModels.Projects;

public class CreateProjectViewModel
{
    public CreateProjectViewModel(){}

    public CreateProjectViewModel(string name, string description, string userEmail)
    {
        Name = name;
        Description = description;
        UserEmail = userEmail;
    }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public string UserEmail { get; set; }


}