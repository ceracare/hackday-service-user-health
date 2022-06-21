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
using System.Net;
using System.Text.Json.Nodes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serviceUserHealth.Controllers;

[ApiController]
[Route("fitbit/05e29076-b9f2-44cf-b47f-368a4c47d73c/sleep")]
public class SleepController : ControllerBase
{
    private readonly ILogger<SleepController> _logger;
    const string TopicARN = "arn:aws:sns:eu-west-1:340568367025:Hack-QA-Fitbit-Notification";
    static RegionEndpoint Region = Amazon.RegionEndpoint.EUWest1;

    public SleepController(ILogger<SleepController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetSleep")]
    public async Task Get()
    {

        Uri myUri = new Uri("https://www.fitbit.com/oauth2/authorize?response_type=code&client_id=238LX9&redirect_uri=https%3A%2F%2Fapp-settings.fitbitdevelopercontent.com%2Fsimple-redirect.html&scope=activity%20heartrate%20location%20nutrition%20profile%20settings%20sleep%20social%20weight%20oxygen_saturation%20respiratory_rate&expires_in=6048000000");
        // Create a 'HttpWebRequest' object for the specified url.
        HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
        // Send the request and wait for response.
        HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
        var redirect = myHttpWebResponse.ResponseUri.ToString();
        var authCode = redirect.Substring(redirect.IndexOf('='), redirect.IndexOf('#'));

        int sleepDuration = 0;

        using (HttpClient client = new HttpClient())
        {
            try
            {

                var parameters = new Dictionary<string, string> { { "client_id", "238LX9" },
                    { "grant_type", "authorization_code" },
                    { "code", authCode } };
                //Uzkoduojama URL'ui 
                var encodedContent = new FormUrlEncodedContent(parameters);
                //Post http callas.
                HttpResponseMessage response = client.PostAsync("https://api.fitbit.com/oauth2/token", encodedContent).Result;
                //nesekmes atveju error..
                response.EnsureSuccessStatusCode();
                //responsas to string
                var responseToken = await response.Content.ReadFromJsonAsync<FitbitToken>();

                var token = responseToken.access_token;

                var httpRequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://api.fitbit.com/1.2/user/-/sleep/date/2022-06-21.json"),
                    Headers = {
            { HttpRequestHeader.Authorization.ToString(), $"Bearer {token}" }
        }
                };

                var sleepResponse = client.SendAsync(httpRequestMessage).Result;

                var sleepResult = response.Content.ReadAsStringAsync().Result;
                var result = JsonNode.Parse(sleepResult);
                sleepDuration = Int32.Parse(result["sleep"][0]["duration"].ToString());

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        if (sleepDuration < 25200000)
        {
            string message = $"{DateTime.Now.ToShortTimeString()} user sleep more";

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
                }
                else
                {
                    Console.WriteLine($"HTTP status {response.HttpStatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in publish action:");
                Console.WriteLine(ex.Message);
            }
        //    return Enumerable.Range(1, 7).Select(index => new Sleep
        //    {
        //        Id = Guid.NewGuid(),
        //        MinutesAsleep = 300,
        //        CreatedAt = DateTime.Now.AddDays(index - 8)
        //    })
        //.ToArray();
        }
    }

}