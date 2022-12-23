using Heathstone.Models;
using Heathstone.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<HearthstoneDBSettings>
    (builder.Configuration.GetSection("HearthstoneDatabase"));
// Add services to the container.
builder.Services.AddSingleton<CardsService>();
builder.Services.AddSingleton<CardTypesService>();
builder.Services.AddSingleton<ClassesService>();
builder.Services.AddSingleton<RaritiesService>();
builder.Services.AddSingleton<SetsService>();

builder.Services.AddControllers();

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseHttpLogging();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
