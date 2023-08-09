using Newtonsoft.Json;
using PublisherJobInfra.Infra.Entities;
using PublisherJobInfra.Infra.Interfaces.WeatherReport;
using RabbitMQ.Client;
using System.Text;

namespace PublisherJobInfra.Infra.Repositories.WeatherReport
{
    public class WeatherReportRepository : IWeatherReportRepository
    {
        public async Task<WeatherReportEntity> GetWeatherReport(string cityId)
        {
            using (HttpClient client = new HttpClient())
            {
                //colocar para receber o Id
                HttpResponseMessage response = await client.GetAsync($"https://weather-report-api.azurewebsites.net/api/weatherreport/?cityId=4750");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                WeatherReportEntity? weatherReport = JsonConvert.DeserializeObject<WeatherReportEntity>(responseBody);

                return weatherReport;
            }
        }
        public void PostWeather(UserWeather weatherReportUser)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "WeatherReport",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(weatherReportUser);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "WeatherReport",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($"[x] Enviada: {message}");
            }
        }
    }
}
