using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Common.Dtos.Projects;
using ToDo.Common.ViewModels.Projects;
using ToDo.Services.Projects.Commands.CreateProject;
using ToDo.Services.Projects.Queries.GetProjects;

namespace ToDo.Server.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<IList<ProjectDto>>> GetProjects()
        => Ok(await _mediator.Send(new GetProjectsQuery()));

    [HttpPost("create")]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectViewModel model)
        => Ok(await _mediator.Send(new CreateProjectCommand(model)));
}