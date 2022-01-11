using Microsoft.AspNetCore.Mvc;
using Service.Models;

namespace Service.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn([FromBody] AuthenticateRQ rq)
    {
        return Ok();
    }
}   
