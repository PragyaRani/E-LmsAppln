using AdminAndInstructor.Microservice.Repository;
using ApiCommonLibrary.Models;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAndInstructor.Microservice.Consumer
{
    public class EnrollCourseConsume : IConsumer<EnrollCourseModel>
    {
        private readonly ILogger<EnrollCourseModel> logger;
        private readonly ICourseRepo courseRepo;

        public EnrollCourseConsume(ILogger<EnrollCourseModel> _logger, ICourseRepo _courseRepo)
        {
            logger = _logger;
            courseRepo = _courseRepo;
        }
        public async Task Consume(ConsumeContext<EnrollCourseModel> context)
        {
            var data = context.Message;
            await Console.Out.WriteLineAsync(context.Message.Student);
            await courseRepo.AddNotification(data);
            logger.LogInformation($"Got new message {context.Message}");

        }
    }
}
