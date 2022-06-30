namespace API;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public decimal TemperatureF => 32M;

    public string? Summary { get; set; }
}
