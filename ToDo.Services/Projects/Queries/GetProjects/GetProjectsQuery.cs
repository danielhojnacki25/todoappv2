using MediatR;
using ToDo.Common.Dtos.Projects;

namespace ToDo.Services.Projects.Queries.GetProjects;

public class GetProjectsQuery : IRequest<IList<ProjectDto>>
{
    public GetProjectsQuery(){}
}