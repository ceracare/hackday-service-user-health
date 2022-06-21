using System;
namespace serviceUserHealth.Models
{
	public class FitbitNotification
	{
        public string? collectionType { get; set; }

        public string? date { get; set; }

        public string? ownerId { get; set; }

        public string? subscriptionId { get; set; }
    }
}
