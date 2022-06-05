using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Data.Models;
using ToDo.Repository.Projects;
using ToDo.Repository.Users;

namespace ToDo.Services.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public CreateProjectCommandHandler(IProjectRepository projectRepository, IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByConditionAsync(x => x.Email.Equals(request.NewProject.UserEmail))
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null) return Unit.Value;

        var newProject = new Project(request.NewProject.Name, request.NewProject.Description, user.Id);
        await _projectRepository.CreateAsync(newProject);

        return Unit.Value;
    }
}