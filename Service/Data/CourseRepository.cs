using Microsoft.EntityFrameworkCore;
using Service.Entities;

namespace Service.Data;

public class CourseRepository : ICourseRepository
{
    private readonly CourseContext _Context;

    public CourseRepository(CourseContext context)
    {
        _Context = context;
    }

    public virtual IQueryable<Course> GetAll()
    {
        return _Context.Courses.AsNoTrackingWithIdentityResolution();
    }

    public async Task<int> Save(Course entity)
    {
        _Context.Courses.Update(entity);

        var rs = await _Context.SaveChangesAsync();

        _Context.Entry(entity).State = EntityState.Detached;

        return rs;
    }
}

public interface ICourseRepository
{
    IQueryable<Course> GetAll();

    Task<int> Save(Course entity);
}