using TickerService.Api.Clients;
using TickerService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IPolygonClient, PolygonClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Polygon:BaseUrl"]);
});

builder.Services.AddDomainServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();