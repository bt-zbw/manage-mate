using Application.Components;
using Application.Database;
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

//Connecting to MQTT Broker
var mqttFactory = new MqttClientFactory();
var mqttClient = mqttFactory.CreateMqttClient();
var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("192.168.10.20").Build();
await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

var applicationMessage = new MqttApplicationMessageBuilder()
    .WithTopic("samples/temperature/living_room")
    .WithPayload("19.5")
    .Build();

await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();