using MLApps.Capstone.Encriptado.Services.WebApi.Modules.App;
using MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAppSettings(builder.Configuration);

var app = builder.Build();
app.AddAppSettings();

app.Run();