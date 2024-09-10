using SoapCore;
using WSMeteoTrento.MeteoTrentoLogic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddScoped<ISoapService, SoapService>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ISoapService>("/Servizio.wsdl",
        new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.Run();