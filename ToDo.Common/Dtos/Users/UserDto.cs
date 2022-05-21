namespace ToDo.Common.Dtos.Users;

public sealed class UserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsAuthenticated { get; set; }
}