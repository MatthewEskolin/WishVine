using Microsoft.AspNetCore.Mvc;
using WishVine.Shared;

namespace WishVine.Server.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class WishListController : ControllerBase
    {
        private readonly ILogger<WishListController> _logger;

        //WishList Storage (get from db later)
        public List<WishList> WishLists = new()
        {
            new WishList() { Name = "Matt's Wish List" },
            new WishList() { Name = "Jerry's Wish List" },
            new WishList() { Name = "Amanda's Wish List" },
        };

        public WishListController(ILogger<WishListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WishList> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WishList()
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }


    }


}