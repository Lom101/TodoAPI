using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("admin")]
    [Authorize("Admin")]
    public IActionResult GetAdminData()
    {
        return Ok("This is protected by Admin role.");
    }

    [HttpGet("user")]
    [Authorize("User")]
    public IActionResult GetUserData()
    {
        return Ok("This is protected by User role.");
    }
    
    [HttpGet("all")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    // controller with authorization without roles
    public IActionResult GetAllData()
    {
        var userClaims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
        return Ok(userClaims);
    }
}