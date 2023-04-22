using Microsoft.AspNetCore.Identity;

namespace DotNet7_WebAPI_JWT.Core.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}
