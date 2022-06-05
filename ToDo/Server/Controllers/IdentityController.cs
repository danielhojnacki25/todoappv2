using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDo.Common.ViewModels.Identities;
using ToDo.Common.ViewModels.Identities.Results;
using ToDo.Data.Models;

namespace ToDo.Server.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;
    public IdentityController(UserManager<User> userManager,
        SignInManager<User> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {

        var newUser = new User{ UserName = model.UserName, Email = model.Email };
        var result = await _userManager.CreateAsync(newUser, model.Password);

        if (result.Succeeded)
        {
            return Ok(new RegisterResult { Successful = true });
        }

        var errors = result.Errors.Select(x => x.Description);

        return Ok(new RegisterResult { Successful = false, Errors = errors });
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        User user; 
        var username = model.EmailOrUsername;

        if (model.EmailOrUsername.Contains(Convert.ToChar("@")))
        {
            user = await _userManager.FindByEmailAsync(model.EmailOrUsername);
            if (user is not null)
            {
                username = user.UserName;
            }
        }
        else
        {
            user = await _userManager.FindByNameAsync(username);
        }

        if (user is null) return Ok(new LoginResult { Successful = false, Token = null });

        var result = await _signInManager.PasswordSignInAsync(username, model.Password, false, false);

        if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Error = "Username and password are invalid." });

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

        var token = new JwtSecurityToken(
            _configuration["JwtIssuer"],
            _configuration["JwtAudience"],
            claims,
            expires: expiry,
            signingCredentials: creds
        );

        return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });

    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LoginViewModel model)
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}