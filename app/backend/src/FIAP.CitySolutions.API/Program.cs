using FIAP.CitySolutions.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddSwaggerConfiguration();
builder.Services.AddAppConfiguration();
builder.Services.AddDataContextConfiguration(builder.Configuration);
builder.Services.ResolveDependencies();

//App
var app = builder.Build();

app.UseAppConfiguration();
app.UseDataContextConfiguration();

app.Run();
