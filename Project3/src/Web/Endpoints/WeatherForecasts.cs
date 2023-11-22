using Project3.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace Project3.Web.Endpoints
{
    public class WeatherForecasts : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .RequireAuthorization()
                .MapGet(GetWeatherForecasts);
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender)
        {
            return await sender.Send(new GetWeatherForecastsQuery());
        }
    }
}