using MediatR;
using ToDo.Common.ViewModels.Projects;

namespace ToDo.Services.Projects.Commands.CreateProject;

public class CreateProjectCommand : IRequest<Unit>
{
    public CreateProjectCommand(CreateProjectViewModel model)
        => NewProject = model;

    public CreateProjectViewModel NewProject { get; set; }
}