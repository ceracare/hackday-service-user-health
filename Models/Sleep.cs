using System;
namespace serviceUserHealth.Models
{
    public class Sleep
    {
        public Guid Id { get; set; }

        public int MinutesAsleep { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
