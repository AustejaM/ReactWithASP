using Microsoft.AspNetCore.Mvc;
using ReactWithASP.Server.Models.DTOs;
using ReactWithASP.Server.Services;
namespace ReactWithASP.Server.Controllers;

[ApiController]
[Route(template: "api/[controller]")]

public class StudentsController(IGetStudentService getStudentService, ISaveStudentService saveStudentService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var results = await getStudentService.GetAll();
        return Ok(results);
    }

    [HttpPut(template:"{id:int}")]

    public async Task<IActionResult> Put(int id, StudentDto dto)
    {
        await saveStudentService.Update(id, dto);
        return Ok();
    }
}
