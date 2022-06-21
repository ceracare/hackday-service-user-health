
namespace serviceUserHealth.Models
{
    public class ServiceUserData
    {
        public Guid Id { get; set; }

        public int Age { get; set; }

        public int MedicationTier { get; set; }

        public AgeBaselineData? AgeData { get; set; }
    }

    public class AgeBaselineData
    {
        public int HeartRateBpm { get; set; }

        public string? HeartRatePercentile { get; set; }

        public int SleepLower { get; set; }

        public int SleepUpper { get; set; }

        public int ModerateExerciseLower { get; set; }

        public int ModerateExerciseUpper { get; set; }

        public int VigorousExerciseLower { get; set;  }

        public int VigorousExerciseUpper { get; set; }
    }
}