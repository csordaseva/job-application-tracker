using JobApplicationTracker.Api.Data;
using JobApplicationTracker.Api.Dtos;
using JobApplicationTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Api.Services
{
    public class JobApplicationService
    {
        private readonly AppDbContext _dbContext;

        public JobApplicationService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<JobApplication>> GetAllAsync()
        {
            return await _dbContext.JobApplications
                .OrderByDescending(application => application.AppliedAt)
                .ToListAsync();
        }

        public async Task<JobApplication?> GetByIdAsync(int id)
        {
            return await _dbContext.JobApplications.FindAsync(id);
        }

        public async Task<JobApplication> CreateAsync(CreateJobApplicationDto dto)
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

            return application;
        }

        public async Task<JobApplication?> UpdateStatusAsync(int id, UpdateJobApplicationStatusDto dto)
        {
            var application = await _dbContext.JobApplications.FindAsync(id);

            if (application is null)
            {
                return null;
            }

            application.Status = dto.Status;
            await _dbContext.SaveChangesAsync();

            return application;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var application = await _dbContext.JobApplications.FindAsync(id);

            if (application is null)
            {
                return false;
            }

            _dbContext.JobApplications.Remove(application);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}