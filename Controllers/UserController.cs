using Microsoft.AspNetCore.Mvc;
using ProductsApi.Application.DTOs.Users;
using ProductsApi.Application.Interfaces;

namespace ProductsApi.API.Controllers;
[ApiController]
[Route("api/user")]
public class UserController :ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("register")]
    public async Task<ActionResult> Register(CreateUsersDto createUsers)
    {
        if (string.IsNullOrWhiteSpace(createUsers.Username) || string.IsNullOrWhiteSpace(createUsers.Password))
        {
            return BadRequest("Username and password are required.");
        }
        var existingUser = await _userService.GetUserByUsername(createUsers.Username);
        if (existingUser != null)
        {
            return Conflict("Username already exists.");
        }
        var result = await _userService.CreateUser(createUsers);
        if (result)
        {
            return Ok("User created successfully.");
        }
        return BadRequest("Failed to create user.");
    }
    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginUsersDto loginUsers)
    {
        var result = await _userService.LoginUser(loginUsers);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest("Invalid username or password.");
    }

}
