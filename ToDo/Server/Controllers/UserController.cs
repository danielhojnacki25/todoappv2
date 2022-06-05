using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Common.Dtos.Users;
using ToDo.Services.Users.Queries.GetUserByUserName;
using ToDo.Services.Users.Queries.GetUsers;

namespace ToDo.Server.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    public UserController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    [HttpGet("{userName}")]
    public async Task<ActionResult<UserDto?>> GetUserByUserName(string userName)
        => Ok(await _mediator.Send(new GetUserByUserNameQuery(userName)));


    [HttpGet("all")]
    public async Task<ActionResult<IList<UserDto>>> GetUsers()
        => Ok(await _mediator.Send(new GetUsersQuery()));
}