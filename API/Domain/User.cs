using Microsoft.AspNetCore.Identity;

namespace API.Domain;

public class User : IdentityUser
{
    public string DisplayName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
}