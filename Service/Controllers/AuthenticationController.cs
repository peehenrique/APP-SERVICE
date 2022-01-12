using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;

namespace Service.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _Service;

    public AuthenticationController(IAuthenticationService service)
    {
        _Service = service;
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn([FromBody] AuthenticateRQ rq)
    {
        var rs = await _Service.Authenticate(rq);

        if (rs is not null)
        {
            return Ok(rs);
        }

        return Unauthorized("Usuario ou senha invalidos");
    }
}   
