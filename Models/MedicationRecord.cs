using System;
namespace serviceUserHealth.Models
{
    public class MedicationRecord
    {
        public Guid Id { get; set; }

        public Boolean Missed { get; set; }

        public String? AlertType { get; set; }

        public DateTime MissedAt { get; set; }

        public DateTime ResolvedAt { get; set; }
    }
}

