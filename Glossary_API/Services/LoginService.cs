using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Glossary_API;

public class LoginService : ILoginService
{
     private readonly IConfiguration _config;

    public LoginService(IConfiguration config)
    {
        _config = config;
    }
    public string Authenticate(User objUser)
    {
        /* logic for login process
        Verify username & password using DB or external AuthenticationService
        then proceed to generate token */

        string token = null;
        var testUsername = "testUser";
        var testPassword = "testPassword";
        if ((objUser.UserName == testUsername) && (objUser.Password == testPassword))
        {
            token = GenerateToken();
        }
        return token;
    }

    private string GenerateToken()
    {
        //Log.Debug("Generate Token for Authentication");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
         _config["Jwt:Issuer"],
          null,
          expires: DateTime.Now.AddMinutes(120),
          signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
        return token;

    }
}
