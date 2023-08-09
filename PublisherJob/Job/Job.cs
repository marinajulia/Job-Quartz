using Microsoft.Extensions.Logging;
using PublisherJob.Service.User;
using PublisherJob.Service.WeatherReport;
using PublisherJobInfra.Infra.Entities;
using Quartz;

namespace PublisherJob.Job
{
    [DisallowConcurrentExecution]
    public class Job : IJob
    {
        private readonly ILogger<Job> _logger;
        private readonly IUserService _userService;
        private readonly IWeatherReportService _weatherReportService;

        public Job(ILogger<Job> logger, IUserService userService, IWeatherReportService weatherReportService)
        {
            _logger = logger;
            _userService = userService;
            _weatherReportService = weatherReportService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Rodando: {time}", DateTimeOffset.Now);

            var userEntities = _userService.Get();
            foreach (var user in userEntities)
            {
                ProcessForecasts(user);
            }

            return Task.CompletedTask;
        }

        private async void ProcessForecasts(UserEntity user)
        {
            var weatherReport = await _weatherReportService.GetWeatherReport(user.IdCity.ToString());

            UserWeather userWeather = new UserWeather()
            {
                Name = user.Name,
                Email = user.Email,
                WeatherReport = new WeatherReportEntity()
                {
                    Cidade = weatherReport.Cidade,
                    estado = weatherReport.estado,
                    atualizado_em = weatherReport.atualizado_em,
                    clima =  weatherReport.clima
                }
            };
            _weatherReportService.PostWeather(userWeather);

            Console.WriteLine(userWeather);
        }
    }
}
