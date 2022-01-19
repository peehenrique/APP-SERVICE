using Service.Data;
using Service.Helpers;
using Service.Models;

namespace Service.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthRepository _Repository;
    private readonly Jwt _Jwt;

    public AuthenticationService(IAuthRepository repository, Jwt jwt)
    {
        _Repository = repository;
        _Jwt = jwt;
    }

    public async Task<AuthenticateRS?> Authenticate(AuthenticateRQ rq)
    {
        var user = await _Repository.GetSingle(e => e.Active == true && e.Username == rq.Username && e.Password == rq.Password);

        if (user is not null)
        {
            var token = _Jwt.GenerateJwtToken(user);

            return new AuthenticateRS(user, token);
        }

        return null;
    }
}

public interface IAuthenticationService
{
    Task<AuthenticateRS?> Authenticate(AuthenticateRQ rq);
}