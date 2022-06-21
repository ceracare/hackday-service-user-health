using System;
namespace serviceUserHealth.Models
{
    // https://dev.ceradev.co.uk/v1/visit/08e6008b-24fc-4c1b-b090-f8cb02035dd8
    public class Mood
    {
        public Guid Id { get; set; }

        public Guid VisitReportGuid { get; set; }

        public Guid VisitGuid { get; set; }

        public int MoodIntegerValue { get; set; }

        public String? MoodStringValue { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
