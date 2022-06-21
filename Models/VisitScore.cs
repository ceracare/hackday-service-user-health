
namespace serviceUserHealth.Models
{
    public class VisitScore
    {
        public Guid Id { get; set; }

        public Guid VisitId { get; set; }

        public int ScoreWeightId { get; set; }

        public double Score { get; set; }

        public int DcpScore { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string? CalculationData { get; set; }
    }
}