namespace Glossary_API;

public class AuthenticationResponse
{
    public AuthenticationResponse(string authToken)
    {
        this.AuthToken = authToken;
    }
    public string AuthToken { get; set; }
}
