using PublisherJobInfra.Infra.Entities;
using PublisherJobInfra.Infra.Interfaces.WeatherReport;

namespace PublisherJob.Service.WeatherReport
{
    public class WeatherReportService : IWeatherReportService
    {
        private readonly IWeatherReportRepository _weatherReportRepository;
        public WeatherReportService(IWeatherReportRepository weatherReportRepository)
        {
            _weatherReportRepository = weatherReportRepository;
        }
        public async Task<WeatherReportEntity> GetWeatherReport(string cityId)
        {
            //TODO: tratar retorno para caso não encontre
            return await _weatherReportRepository.GetWeatherReport(cityId);
        }
        public void PostWeather(UserWeather weatherReport)
        {
            _weatherReportRepository.PostWeather(weatherReport);
        }
    }
}
