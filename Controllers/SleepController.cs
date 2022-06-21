using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using serviceUserHealth.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serviceUserHealth.Controllers;

[ApiController]
[Route("fitbit/05e29076-b9f2-44cf-b47f-368a4c47d73c/sleep")]
public class SleepController : ControllerBase
{
    private readonly ILogger<SleepController> _logger;

    public SleepController(ILogger<SleepController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetSleep")]
    public IEnumerable<Sleep> Get()
    {
        return Enumerable.Range(1, 7).Select(index => new Sleep
        {
            Id = Guid.NewGuid(),
            MinutesAsleep = 300,
            CreatedAt = DateTime.Now.AddDays(index - 8)
        })
        .ToArray();
    }
}

