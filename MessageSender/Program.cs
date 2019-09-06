using MessageSender.Models;
using MessageSender.Services;
using System;

namespace MessageSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var MAX_LIMIT = 500;
            var eventHubInfo = new EventHubInfo
            {
                EventHubConnectionString = Environment.GetEnvironmentVariable("EHConnectionString"),
                EventHubPath = Environment.GetEnvironmentVariable("EHPath"),
                NoOfMessages = MAX_LIMIT
            };

            var submitter = new SensorReadingDataSubmitter();
            var status = submitter.Submit(eventHubInfo).Result;

            Console.WriteLine("Submission Status : " + status);
            Console.WriteLine("Event Messages have been submitted successfully!");
        }
    }
}
