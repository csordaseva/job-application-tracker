using JobApplicationTracker.Api.Models;

namespace JobApplicationTracker.Api.Dtos
{
    public class UpdateJobApplicationStatusDto
    {
        public JobApplicationStatus Status { get; set; }
    }
}
