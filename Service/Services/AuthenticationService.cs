using Service.Data;
using Service.Models;

namespace Service.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthRepository _Repository;

    public AuthenticationService(IAuthRepository repository)
    {
        _Repository = repository;
    }

    public async Task<AuthenticateRS?> Authenticate(AuthenticateRQ rq)
    {
        var user = await _Repository.GetSingle(e => e.Active == true && e.Username == rq.Username && e.Password == rq.Password);

        //Example token generation
        var token = Guid.NewGuid().ToString();

        if (user is not null)
        {
            return new AuthenticateRS(user, token);
        }

        return null;
    }
}

public interface IAuthenticationService
{
    Task<AuthenticateRS?> Authenticate(AuthenticateRQ rq);
}