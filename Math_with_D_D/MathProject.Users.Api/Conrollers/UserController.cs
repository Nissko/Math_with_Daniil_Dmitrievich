using Microsoft.AspNetCore.Mvc;

namespace MathProject.Users.Api.Conrollers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(new[] { "User1", "User2" });
    }
}