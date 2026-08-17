using JobApplicationTracker.Api.Data;
using JobApplicationTracker.Api.Models;
using JobApplicationTracker.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobApplicationsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public JobApplicationsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<JobApplication>>> GetAll()
    {
        var applications = await _dbContext.JobApplications
            .OrderByDescending(application => application.AppliedAt)
            .ToListAsync();

        return Ok(applications);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<JobApplication>> GetById(int id)
    {
        var application = await _dbContext.JobApplications.FindAsync(id);

        if (application is null)
        {
            return NotFound();
        }

        return Ok(application);
    }

    [HttpPost]
    public async Task<ActionResult<JobApplication>> Create(CreateJobApplicationDto dto)
    {
        var application = new JobApplication
        {
            Company = dto.Company,
            Position = dto.Position,
            Notes = dto.Notes,
            Location = dto.Location
        };


        _dbContext.JobApplications.Add(application);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = application.Id },
            application);
    }

    [HttpPatch("{id:int}/status")]
    public async Task<ActionResult<JobApplication>> UpdateStatus(
    int id,
    UpdateJobApplicationStatusDto dto)
    {
        var application = await _dbContext.JobApplications.FindAsync(id);

        if (application is null)
        {
            return NotFound();
        }

        application.Status = dto.Status;

        await _dbContext.SaveChangesAsync();

        return Ok(application);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var application = await _dbContext.JobApplications.FindAsync(id);

        if (application is null)
        {
            return NotFound();
        }

        _dbContext.JobApplications.Remove(application);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}
