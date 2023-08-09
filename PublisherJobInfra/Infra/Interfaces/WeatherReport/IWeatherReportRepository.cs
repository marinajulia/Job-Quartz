using PublisherJobInfra.Infra.Entities;

namespace PublisherJobInfra.Infra.Interfaces.WeatherReport
{
    public interface IWeatherReportRepository
    {
        Task<WeatherReportEntity> GetWeatherReport(string cityId);
        void PostWeather(UserWeather weatherReport);
    }
}
