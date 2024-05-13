using Glossary_API;
using Microsoft.Extensions.Configuration;

namespace Glossary_Test;

public class LoginUnitTest
{
        private readonly ILoginService _loginService;


    public LoginUnitTest()
    {
        var configuration = new Dictionary<string, string>
        {
            {"Jwt:Key", "YourSecretKeyForAuthenticationOfApplication"},
            {"Jwt:Issuer", "yourCompanyIssuer.com"}
        };

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(configuration)
            .Build();

        _loginService = new LoginService(config);
    }

    [Fact]
    public void AuthenticateUser_Returns_Token()
    {
        //Arrange
        var _objUser = new User();
        _objUser.UserName = "testUser";
        _objUser.Password = "testPassword";

        //Act
        var actualResult = _loginService.Authenticate(_objUser);

        //Assert
        Assert.NotNull(actualResult);
    }

    [Fact]
    public void AuthenticateUser_Incorrect_User()
    {
        //Arrange
        var _objUser = new User();
        _objUser.UserName = "testUser1";
        _objUser.Password = "testPassword";

        //Act
        var actualResult = _loginService.Authenticate(_objUser);

        //Assert
        Assert.Null(actualResult);
    }

    [Fact]
    public void AuthenticateUser_Incorrect_Password()
    {
        //Arrange
        var _objUser = new User();
        _objUser.UserName = "testUser";
        _objUser.Password = "testPassword1";

        //Act
        var actualResult = _loginService.Authenticate(_objUser);

        //Assert
        Assert.Null(actualResult);
    }
}
