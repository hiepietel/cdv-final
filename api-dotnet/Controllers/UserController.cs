using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Controllers;

[ApiController]
//[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("/api/users")]
    public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
    {
        var token = await _userService.Register(userDto);
        return Ok(new
        {
            access_token = token,
            token_type = "bearer"
        });
    }

    [HttpPost]
    [Route("/api/token")]
    public async Task<IActionResult> GenerateToken([FromBody] UserDto userDto)
    {
        var token = await _userService.Login(userDto);
        return Ok(new
        {
            access_token = token,
            token_type = "bearer"
        });
    }

    [HttpGet]
    [Route("api/users/me")]
    public async Task<IActionResult> GetUser()
    {
        await _userService.GetMe();
        return Ok();
    }
}