using Microsoft.EntityFrameworkCore;
using Service.Data;
using Service.Entities;

namespace Service.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _Repository;

    public CourseService(ICourseRepository repository)
    {
        _Repository = repository;
    }

    public async Task<IEnumerable<Course>> GetAll()
    {
        return await _Repository.GetAll().ToListAsync();
    }

    public async Task<int> Save(Course entity)
    {
        return await _Repository.Save(entity);
    }
}

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAll();
    Task<int> Save(Course entity);
}