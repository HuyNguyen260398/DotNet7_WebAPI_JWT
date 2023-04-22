using DotNet7_WebAPI_JWT.Core.Dtos;
using DotNet7_WebAPI_JWT.Core.Entities;
using DotNet7_WebAPI_JWT.Core.Interfaces;
using DotNet7_WebAPI_JWT.Core.OtherObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace DotNet7_WebAPI_JWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Route for seeding my roles to db
    [HttpPost]
    [Route("seed-roles")]
    public async Task<IActionResult> SeedRoles()
    {
        var seedRoles = await _authService.SeedRolesAsync();

        return Ok(seedRoles);
    }

    // Route -> Register
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var registerResult = await _authService.RegisterAsync(registerDto);

        if (registerResult.IsSucceed)
            return Ok(registerResult);

        return BadRequest(registerResult);
    }

    // Route -> Login
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var loginResult = await _authService.LoginAsync(loginDto);

        if (loginResult.IsSucceed)
            return Ok(loginResult);

        return Unauthorized(loginResult);
    }

    

    // Route -> make user to admin
    [HttpPost]
    [Route("make-admin")]
    public async Task<IActionResult> MakeAdmin([FromBody] UpdatePermissionDto updatePermissionDto)
    {
        var operationResult = await _authService.MakeAdminAsync(updatePermissionDto);

        if (operationResult.IsSucceed)
            return Ok(operationResult);

        return BadRequest(operationResult);
    }

    // Route -> make user to owner
    [HttpPost]
    [Route("make-owner")]
    public async Task<IActionResult> MakeOwner([FromBody] UpdatePermissionDto updatePermissionDto)
    {
        var operationResult = await _authService.MakeOwnerAsync(updatePermissionDto);

        if (operationResult.IsSucceed)
            return Ok(operationResult);

        return BadRequest(operationResult);
    }
}
