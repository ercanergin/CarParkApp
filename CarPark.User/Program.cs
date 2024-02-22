using CarPark.Core.Repository.Abstract;
using CarPark.Core.Settings;
using CarPark.DataAccess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System.Configuration;
using System.Globalization;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt")
    .WriteTo.Seq("http://localhost:5341/")
    .MinimumLevel.Information()
    .Enrich.WithProperty("ApplicationName", "CarPark.User")
    .Enrich.WithMachineName()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(); // <-- Add this line
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

builder.Services.AddMvc()
    .AddDataAnnotationsLocalization();
//bunlarý test için ekledik sonrasýnda sileceðiz.Hiçbir zaman user katmaný core ve business katmanýna eriþemez direk.
builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepositoryBase<>));

builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR"),
        new CultureInfo("ar-SA")
    };

    opt.DefaultRequestCulture = new RequestCulture("tr-TR");
    opt.SupportedCultures = supportedCultures;
    opt.SupportedUICultures = supportedCultures;

    opt.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider(),
        new AcceptLanguageHeaderRequestCultureProvider()
    };

});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

var options = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(options.Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

