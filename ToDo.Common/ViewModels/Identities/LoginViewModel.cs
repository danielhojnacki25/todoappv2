using System.ComponentModel.DataAnnotations;

namespace ToDo.Common.ViewModels.Identities;

public class LoginViewModel
{
    [Required]
    public string EmailOrUsername { get; set; }

    [Required]
    public string Password { get; set; }
}