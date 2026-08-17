namespace JobApplicationTracker.Api.Models;

public class JobApplication
{
    public int Id { get; set; }

    public string Company { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

    public JobApplicationStatus Status { get; set; } = JobApplicationStatus.Applied;

    public string? Notes { get; set; }

    public string? Location { get; set; }
}
