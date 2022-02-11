namespace Api;

public static class WeatherForecast
{
    [FunctionName(nameof(WeatherForecast))]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function,
        "get", Route = "weather-forecast/{daysToForecast=5}")]
        HttpRequest req, ILogger log, int daysToForecast)
    {
        return new OkObjectResult(GetWeather(daysToForecast));
    }

    private static dynamic[] GetWeather(int daysToForecast)
    {
        var enumerator = Enumerable.Range(1, daysToForecast);
        var result = new List<dynamic>();
        var rnd = new Random();

        foreach (var day in enumerator)
        {
            var temp = rnd.Next(25);
            var summary = GetSummary(temp);
            result.Add(new
            {
                Date = DateTime.Now.AddDays(day),
                Summary = summary,
                TemperatureC = temp
            });
        }

        return result.ToArray();
    }

    private static object GetSummary(int temp)
    {
        return temp switch
        {
            > 20 => "Hot!",
            > 15 => "Warm",
            > 10 => "Cool",
            > 5 => "Cold",
            _ => "Too cold!",
        };
    }
}
