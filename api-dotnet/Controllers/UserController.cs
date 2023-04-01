using Microsoft.AspNetCore.Mvc;

namespace api_dotnet.Controllers;

[ApiController]
//[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpPost]
    [Route("/api/users")]
    public async Task<IActionResult> CreateUser(){
        
        return Ok("test");
    }

    [HttpPost]
    [Route("/api/token")]
    public async Task<IActionResult> GenerateToken(){
        return Ok();
    }

    [HttpGet]
    [Route("api/users/me")]
    public async Task<IActionResult> GetUser(){
        return Ok();
    }
}