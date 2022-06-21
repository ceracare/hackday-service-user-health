using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using serviceUserHealth.Models;
using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Amazon.SQS;
using Amazon.SQS.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serviceUserHealth.Controllers;

[ApiController]
[Route("fitbit/notification")]
public class FitbitNotificationController : ControllerBase
{
    private readonly ILogger<FitbitNotificationController> _logger;
    const string TopicARN = "arn:aws:sns:eu-west-1:340568367025:Hack-QA-Fitbit-Notification";
    static RegionEndpoint Region = Amazon.RegionEndpoint.EUWest1;

    public FitbitNotificationController(ILogger<FitbitNotificationController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostFitbitNotification")]
    public async Task<IActionResult> Post([FromQuery(Name = "verify")] string verify)
    {

        if(verify == "0d7dd5b02992f05ecc22b41c1978c938410b1252b236fe76d1350264735b720b")
        {
            return new NoContentResult();
        } else
        {
            return new NotFoundResult();
        }

        string message = $"{DateTime.Now.ToShortTimeString()} fitbit sleep data synced";

        var notificationClient = new AmazonSimpleNotificationServiceClient(region: Region);

        var request = new PublishRequest
        {
            Message = message,
            TopicArn = TopicARN
        };

        try
        {
            Console.WriteLine("Publishing...");
            var response = await notificationClient.PublishAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Message sent to topic:");
                Console.WriteLine(message);
                return new NoContentResult();
            }
            else
            {
                Console.WriteLine($"HTTP status {response.HttpStatusCode}");
                return new NoContentResult();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in publish action:");
            Console.WriteLine(ex.Message);
            return new NoContentResult();
        }
        // arn:aws:sns:eu-west-1:340568367025:Hack-QA-Fitbit-Notification
        //return Results.NoContent();
    }
}

