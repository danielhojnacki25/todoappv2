using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Common.Dtos.AppTasks;
using ToDo.Common.Dtos.AppTasks.Filters;
using ToDo.Common.ViewModels.AppTasks;
using ToDo.Services.AppTasks.Commands.CreateTask;
using ToDo.Services.AppTasks.Commands.DeleteTask;
using ToDo.Services.AppTasks.Queries.GetAppTaskById;
using ToDo.Services.AppTasks.Queries.GetAppTasksByUser;

namespace ToDo.Server.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost("create")]
    public async Task<IActionResult> CreateTask([FromBody] CreateAppTaskVewModel model)
        => Ok(await _mediator.Send(new CreateTaskCommand(model)));

    [HttpPost("delete")]
    public async Task<IActionResult> CreateTask([FromBody] long taskId)
        => Ok(await _mediator.Send(new DeleteTaskCommand(taskId)));

    [HttpGet("task/{taskId}")]
    public async Task<ActionResult<AppTaskDto>> GetTaskById(long taskId)
        => Ok(await _mediator.Send(new GetAppTaskByIdQuery(taskId)));

    [HttpGet("user/{userId}/tasks")]
    public async Task<ActionResult<IList<AppTaskDto>>> GetTasksByUser(string userId)
        => Ok(await _mediator.Send(new GetAppTasksByUserQuery(userId, new AppTaskDtoFilter())));
}