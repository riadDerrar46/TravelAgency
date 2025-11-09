using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpGet("login")]
    public IActionResult Login([FromQuery] string email, [FromQuery] string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            return BadRequest("Missing email or password.");

        // Do NOT log the password. Authenticate here.
        return Ok(new { email });
    }
}