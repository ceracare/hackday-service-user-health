using Microsoft.AspNetCore.Mvc;
using serviceUserHealth.Models;

namespace serviceUserHealth.Controllers;

[ApiController]
[Route("mood/05e29076-b9f2-44cf-b47f-368a4c47d73c/trend")]
public class MoodTrendController : ControllerBase
{
    private readonly ILogger<MoodTrendController> _logger;

    public MoodTrendController(ILogger<MoodTrendController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMoodTrend")]
    public IEnumerable<Mood> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Mood
        {
            Id = new Guid(),
            VisitGuid = new Guid(),
            VisitReportGuid = new Guid(),
            MoodStringValue = "Normal",
            MoodIntegerValue = 3
        })
        .ToArray();
    }
}

