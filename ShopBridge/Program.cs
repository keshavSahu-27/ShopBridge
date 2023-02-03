using ShopBridge;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.GetConnectionString("Database");
builder.Services.RegisterServices(configuration);
var app = builder.Build();
app.ConfigureMiddleware();

app.Run();

