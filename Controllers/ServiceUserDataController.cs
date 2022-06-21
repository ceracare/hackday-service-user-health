using Microsoft.AspNetCore.Mvc;
using serviceUserHealth.Models;

namespace serviceUserHealth.Controllers;

[ApiController]
[Route("serviceuser/05e29076-b9f2-44cf-b47f-368a4c47d73c/data")]
public class ServiceUserDataController : ControllerBase
{
    private readonly ILogger<ServiceUserDataController> _logger;

    public ServiceUserDataController(ILogger<ServiceUserDataController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetServiceUserData")]
    public ServiceUserData Get()
    {
        return new ServiceUserData
        {
            Age = 79,
            MedicationTier = 1,
            AgeData = new AgeBaselineData
            {
                HeartRateBpm = 86,
                HeartRatePercentile = "90th",
                SleepLower = 7,
                SleepUpper = 8,
                ModerateExerciseLower = 150,
                ModerateExerciseUpper = 300,
                VigorousExerciseLower = 75,
                VigorousExerciseUpper = 150
            }
        };
    }
}

