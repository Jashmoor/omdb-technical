using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovieDatabase.Core.Clients;
using MovieDatabase.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MovieClientConfiguration>(builder.Configuration.GetSection("MovieClientConfiguration"));
builder.Services.AddResponseCaching();
builder.Services.AddHttpClient("MovieDatabaseClient");
builder.Services.AddTransient<MovieDatabaseClient>(context =>
{
    var config = context.GetRequiredService<IOptions<MovieClientConfiguration>>();
    var factory = context.GetRequiredService<IHttpClientFactory>();
    var client = factory.CreateClient("MoveDatabaseClient");
    return new MovieDatabaseClient(client, config);
});
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.UseResponseCaching();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
