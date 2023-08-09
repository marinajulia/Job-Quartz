using PublisherJobInfra.Infra.Entities;

namespace PublisherJob.Service.WeatherReport
{
    public interface IWeatherReportService
    {
        Task<WeatherReportEntity> GetWeatherReport(string cityId);
        void PostWeather(UserWeather weatherReport);
    }
}
