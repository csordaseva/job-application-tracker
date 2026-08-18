using JobApplicationTracker.Api.Data;
using JobApplicationTracker.Api.Models;
using JobApplicationTracker.Api.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Tests
{
    public class JobApplicationServiceTests
    {

        private static async Task<(SqliteConnection Connection, AppDbContext DbContext)> CreateDbContextAsync()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            await connection.OpenAsync();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connection)
                .Options;

            var dbContext = new AppDbContext(options);
            await dbContext.Database.EnsureCreatedAsync();

            return (connection, dbContext);
        }
        [Fact]
        public async Task GetByIdAsync_WhenJobApplicationExists_ReturnsJobApplication()
        {
            // Arrange
            var (connection, dbContext) = await CreateDbContextAsync();
            await using var _ = connection;
            await using var __ = dbContext;

            var service = new JobApplicationService(dbContext);

            var application = new JobApplication
            {
                Company = "Bosch",
                Position = "Software Developer",
                Location = "Budapest"
            };

            dbContext.JobApplications.Add(application);
            await dbContext.SaveChangesAsync();

            // Act
            var result = await service.GetByIdAsync(application.Id);
        

            // Assert
            Assert.NotNull(result);
            Assert.Equal(application.Id, result.Id);
            Assert.Equal(application.Company, result.Company);
            Assert.Equal(application.Position, result.Position);
            Assert.Equal(application.Location, result.Location);
        }

        [Fact]
        public async Task GetByIdAsync_WhenJobApplicationDoesNotExist_ReturnsNull()
        {
            // Arrange
            var (connection, dbContext) = await CreateDbContextAsync();
            await using var _ = connection;
            await using var __ = dbContext;

            var service = new JobApplicationService(dbContext);

            // Act
            var result = await service.GetByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsJobApplicationsOrderedByAppliedAtDescending()
        {
            // Arrange
            var (connection, dbContext) = await CreateDbContextAsync();
            await using var _ = connection;
            await using var __ = dbContext;

            var olderApplication = new JobApplication
            {
                Company = "Older Company",
                Position = "Developer",
                AppliedAt = new DateTime(2026, 7, 1)
            };

            var newerApplication = new JobApplication
            {
                Company = "Newer Company",
                Position = "Software Developer",
                AppliedAt = new DateTime(2026, 8, 1)
            };

            dbContext.JobApplications.AddRange(
                olderApplication,
                newerApplication);

            await dbContext.SaveChangesAsync();

            var service = new JobApplicationService(dbContext);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(newerApplication.Id, result[0].Id);
            Assert.Equal(olderApplication.Id, result[1].Id);
        }
    }
}