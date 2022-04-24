using Microsoft.AspNetCore.Mvc;
using TestApplication.RabbitMq.Bus.BusRabbit;
using TestApplication.RabbitMq.Bus.EventQueue;

namespace TestApplication.Api.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRabbitEventBus _eventBus;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRabbitEventBus rabbitEventBus)
        {
            _logger = logger;
            _eventBus = rabbitEventBus;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            _eventBus.Publish(new EmailEventQueue("test@test.com", "titulo", "Esto es un ejemplo"));

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}