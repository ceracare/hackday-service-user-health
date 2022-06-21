using Microsoft.AspNetCore.Mvc;
using serviceUserHealth.Models;

namespace serviceUserHealth.Controllers;

[ApiController]
[Route("riskscore/05e29076-b9f2-44cf-b47f-368a4c47d73c/trend")]
public class RiskScoreTrendController : ControllerBase
{
    private readonly ILogger<RiskScoreTrendController> _logger;

    public RiskScoreTrendController(ILogger<RiskScoreTrendController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetRiskScoreTrend")]
    public IEnumerable<VisitScore> Get()
    {
        var aboveAverage = Enumerable.Range(1, 3).Select(index => new VisitScore
        {
            Id = Guid.NewGuid(),
            VisitId = Guid.NewGuid(),
            Score = 0.5431,
            CreatedAt = DateTime.Now.AddDays(index - 8)
        }).ToArray();
        var belowAverage = Enumerable.Range(1, 2).Select(index => new VisitScore
        {
            Id = Guid.NewGuid(),
            VisitId = Guid.NewGuid(),
            Score = -0.5431,
            CreatedAt = DateTime.Now.AddDays(index - 5)
        }).ToArray();
        var average = Enumerable.Range(1, 2).Select(index => new VisitScore
        {
            Id = Guid.NewGuid(),
            VisitId = Guid.NewGuid(),
            Score = 0.00,
            CreatedAt = DateTime.Now.AddDays(index - 3)
        }).ToArray();
        var finalArray = aboveAverage.Concat(belowAverage).Concat(average).ToArray();
        return finalArray;
    }
}

