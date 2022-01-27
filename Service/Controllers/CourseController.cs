using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Entities;
using Service.Services;

namespace Service.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _Service;

    public CourseController(ICourseService service)
    {
        _Service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _Service.GetAll();

        return Ok(entities);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Course rq)
    {
        var entity = await _Service.Save(rq);

        return Ok(entity);
    }
}
