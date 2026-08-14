namespace JobApplicationTracker.Api.Models;

public class JobApplication
{
    public int Id { get; set; }

    public string Company { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "Applied";

    public string? Notes { get; set; }
}
