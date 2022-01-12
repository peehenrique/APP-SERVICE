using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Service.Entities;

namespace Service.Data;

public class AuthRepository : IAuthRepository
{
    private readonly CourseContext _Context;

    public AuthRepository(CourseContext context)
    {
        _Context = context;
    }    

    public async Task<User?> GetSingle(Expression<Func<User, bool>> predicate)
    {
       var entity = await _Context.Users.Where(predicate).AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync();

       return entity;
    }
}

public interface IAuthRepository
{
    Task<User?> GetSingle(Expression<Func<User, bool>> predicate);
}