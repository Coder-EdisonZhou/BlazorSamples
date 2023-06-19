using EDT.BlazorServer.App.Models;
using EDT.BlazorServer.App.Service;
using EDT.BlazorServer.App.Service.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// Add business services 
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<ITodoItemService, TodoItemService>();
builder.Services.AddScoped<PizzaSalesState>();
// Add database context
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
// Add Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Use Localization
const string CULTURE_CHINESE = "zh-CN";
const string CULTURE_ENGLISTH = "en-US";
const string CULTURE_GERMAN = "de-DE";
app.UseRequestLocalization(options =>
{
    var cultures = new[] { CULTURE_CHINESE, CULTURE_ENGLISTH, CULTURE_GERMAN };
    options.AddSupportedCultures(cultures);
    options.AddSupportedUICultures(cultures);
    options.SetDefaultCulture(CULTURE_CHINESE);
    // 当Http响应时，将 当前区域信息 设置到 Response Header：Content-Language 中
    options.ApplyCurrentCultureToResponseHeaders = true;
});

// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();
