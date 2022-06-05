using ToDo.Common.Dtos.Projects;
using ToDo.Data.Models;

namespace ToDo.Repository.Projects;

public interface IProjectRepository : IBaseRepository<Project>
{
    Task<IList<Project>> GetProjectsAsync();
}