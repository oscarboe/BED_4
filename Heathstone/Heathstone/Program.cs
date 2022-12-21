using Heathstone.Models;
using Heathstone.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<HearthstoneDBSettings>
    (builder.Configuration.GetSection(nameof(HearthstoneDBSettings)));
// Add services to the container.
builder.Services.AddSingleton<CardsService>();




var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.Run();
