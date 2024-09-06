using AspNetCore.Identity.MongoDbCore.Models;
using CarPark.Business.Abstract;
using CarPark.Business.Concrete;
using CarPark.Core.Repository.Abstract;
using CarPark.DataAccess.Abstract;
using CarPark.DataAccess.Concrete;
using CarPark.DataAccess.Repository;
using CarPark.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Serilog;
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

builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = IdentityConstants.ApplicationScheme;
    option.DefaultSignInScheme = IdentityConstants.ExternalScheme;
});

//bunlarý test için ekledik sonrasýnda sileceðiz.Hiçbir zaman user katmaný core ve business katmanýna eriþemez direk.
builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepositoryBase<>));
//IPersonelDataAccess inject ettiðimde sen bana PersonelDataAccess new le demek.
builder.Services.AddScoped<IPersonelDataAccess, PersonelDataAccess>();
builder.Services.AddScoped<IPersonelService, PersonelManager>();

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

//builder.Services.AddIdentityCore<Personel>(option =>
//{

//})
//    .AddRoles<MongoIdentityRole>()
//    .AddMongoDbStores<Personel, MongoIdentityRole, Guid>(app.Configuration.GetSection("MongoConnection:ConnectionString").Value, app.Configuration.GetSection("MongoConnection:Database").Value)
//    .AddSignInManager()
//    .AddDefaultTokenProviders();

//builder.Services.ConfigureApplicationCookie(option =>
//{
//    option.Cookie.HttpOnly = true;
//    option.ExpireTimeSpan = TimeSpan.FromMinutes(5);

//    option.LoginPath = "/Account/Login";
//    option.SlidingExpiration = true;
//});

//app.MapGet("/", () => "Hello World!");

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

var options = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(options.Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

