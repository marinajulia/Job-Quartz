namespace PublisherJobInfra.Infra.Entities
{
    public class UserWeather
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public WeatherReportEntity? WeatherReport { get; set; }
    }
}
