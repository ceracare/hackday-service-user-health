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
        var normal = Enumerable.Range(1, 3).Select(index => new Mood
        {
            Id = Guid.NewGuid(),
            VisitGuid = Guid.NewGuid(),
            VisitReportGuid = Guid.NewGuid(),
            MoodStringValue = "Normal",
            MoodIntegerValue = 3,
            CreatedAt = DateTime.Now.AddDays(index - 8)
        })
        .ToArray();
        var belowPar = Enumerable.Range(1, 2).Select(index => new Mood
        {
            Id = Guid.NewGuid(),
            VisitGuid = Guid.NewGuid(),
            VisitReportGuid = Guid.NewGuid(),
            MoodStringValue = "Below Par",
            MoodIntegerValue = 2,
            CreatedAt = DateTime.Now.AddDays(index - 5)
        })
        .ToArray();
        var happy = Enumerable.Range(1, 2).Select(index => new Mood
        {
            Id = Guid.NewGuid(),
            VisitGuid = Guid.NewGuid(),
            VisitReportGuid = Guid.NewGuid(),
            MoodStringValue = "Happy",
            MoodIntegerValue = 5,
            CreatedAt = DateTime.Now.AddDays(index - 3)
        })
        .ToArray();
        var finalArray = normal.Concat(belowPar).Concat(happy).ToArray();
        return finalArray;
    }
}

