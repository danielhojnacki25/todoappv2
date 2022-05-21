namespace ToDo.Common.ViewModels.Identities.Results;

public class RegisterResult
{
    public bool Successful { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}