using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Glossary_API;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public IActionResult AuthenticateUser([FromBody] User objUser)
    {
        try
        {
            var token = _loginService.Authenticate(objUser);
            if (token == null)
            {
                return BadRequest(AppConstants.LOGIN_FAILURE_MESSAGE);
            }
            return Ok(new AuthenticationResponse(token));
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}