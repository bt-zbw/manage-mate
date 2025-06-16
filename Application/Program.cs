using Application.Components;
using Application.Database;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using MQTTnet;

var builder = WebApplication.CreateBuilder(args);

// Register ApplicationDbContext using a factory
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Apply migrations automatically in Development
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

MqttController.IninalizeMqttController("192.168.10.20");
MqttController.Controller.AddLightSensor("light/1");
MqttController.Controller.AddLightSensor("light/2");
MqttController.Controller.AddLightSensor("light/3");
MqttController.Controller.AddTemperatureSensor("temperature/1");
MqttController.Controller.AddTemperatureSensor("temperature/2");
MqttController.Controller.AddDoorSensor("door/1");

app.Run();