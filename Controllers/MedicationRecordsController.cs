using Microsoft.AspNetCore.Mvc;
using serviceUserHealth.Models;

namespace serviceUserHealth.Controllers;

[ApiController]
[Route("medication/05e29076-b9f2-44cf-b47f-368a4c47d73c/records")]
public class MedicationRecordsController : ControllerBase
{
    private readonly ILogger<MedicationRecordsController> _logger;

    public MedicationRecordsController(ILogger<MedicationRecordsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMedicationsRecord")]
    public IEnumerable<MedicationRecord> Get()
    {
        return Enumerable.Range(1, 7).Select(index => new MedicationRecord
        {
            Id = Guid.NewGuid(),
            Missed = true,
            MissedAt = DateTime.Now.AddDays(index - 8),
            ResolvedAt = DateTime.Now.AddDays(index - 5)
    })
        .ToArray();
    }
}

