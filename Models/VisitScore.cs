
namespace serviceUserHealth.Models
{
    public class VisitScore
    {
        public Guid Id { get; set; }

        public Guid VisitId { get; set; }

        public double Score { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}