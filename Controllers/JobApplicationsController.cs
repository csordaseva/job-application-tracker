using JobApplicationTracker.Api.Data;
using JobApplicationTracker.Api.Dtos;
using JobApplicationTracker.Api.Models;
using JobApplicationTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobApplicationsController : ControllerBase
{
    private readonly JobApplicationService _service;

    public JobApplicationsController(JobApplicationService service)
    {
        _service = service;
    }

    [HttpGet]
    [HttpGet]
    public async Task<ActionResult<List<JobApplication>>> GetAll()
    {
        var applications = await _service.GetAllAsync();

        return Ok(applications);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<JobApplication>> GetById(int id)
    {
        var application = await _service.GetByIdAsync(id);

        if (application is null)
        {
            return NotFound();
        }

        return Ok(application);
    }

    [HttpPost]
    public async Task<ActionResult<JobApplication>> Create(CreateJobApplicationDto dto)
    {
        var application = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = application.Id },
            application);
    }

    [HttpPatch("{id:int}/status")]
    public async Task<ActionResult<JobApplication>> UpdateStatus(int id, UpdateJobApplicationStatusDto dto)
    {
        var application = await _service.UpdateStatusAsync(id, dto);

        if (application is null)
        {
            return NotFound();
        }

        return Ok(application);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}