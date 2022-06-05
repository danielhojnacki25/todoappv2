using MediatR;
using ToDo.Common.Dtos.Projects;
using ToDo.Mappers.Projects;
using ToDo.Repository.Projects;

namespace ToDo.Services.Projects.Queries.GetProjects;

public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, IList<ProjectDto>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectsQueryHandler(IProjectRepository projectRepository)
        => _projectRepository = projectRepository;

    public async Task<IList<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetProjectsAsync();
        return projects.Select(x => x.MapToDto()).ToList();
    }
}