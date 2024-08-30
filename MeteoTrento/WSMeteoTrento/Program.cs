using SoapCore;
using WeatherTrentoService.Logic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IWeatherService>("/WeatherService.wsdl",
        new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.Run();