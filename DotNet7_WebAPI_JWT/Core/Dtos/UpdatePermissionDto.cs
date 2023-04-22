using System.ComponentModel.DataAnnotations;

namespace DotNet7_WebAPI_JWT.Core.Dtos;

public class UpdatePermissionDto
{
    [Required(ErrorMessage = "UserName is required")]
    public string UserName { get; set; }
}
