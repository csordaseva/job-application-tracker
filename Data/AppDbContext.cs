using JobApplicationTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
}
