using CarPark.Entities.Concrete;
using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;


namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly MongoClient _client;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
            _client = new MongoClient("mongodb+srv://eergin:Ercoergin25@carparkcluster.vw5n8.mongodb.net/CarParkDB?retryWrites=true&w=majority");
        }

        public IActionResult Index()
        {
            //var say_Hello_value = _localizer["Say_Hello"];

            //var cultureInfo = CultureInfo.GetCultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = cultureInfo;
            //Thread.CurrentThread.CurrentUICulture = cultureInfo;

            //var say_Hello_value2 = _localizer["Say_Hello"];

            //var customer = new Customer
            //{
            //    Id = 1,
            //    NameSurname = "Ercan Ergin",
            //    Age = 29
            //};

            //_logger.LogError("Customerda bir hata oluştu {@customer}", customer);

            var client = new MongoClient("mongodb+srv://.vw5n8.mongodb.net/CarParkDB?retryWrites=true&w=majority");

            var database = _client.GetDatabase("CarParkDB");

            // cities.json dosyasının bulunduğu dizinden okuyorum.
            var jsonString = System.IO.File.ReadAllText("cities.json");

            //Newtonsoft.Json kütüphanesi ile modelime desiralize ediyorum.
            var cities = JsonConvert.DeserializeObject<List<cities>>(jsonString);

            var citiesCollection = database.GetCollection<City>("City");

            foreach (var itemCity in cities)
            {
                var city = new City()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = itemCity.name,
                    Plate = itemCity.plate,
                    Latitude = itemCity.latitude,
                    Longitude = itemCity.longitude,
                    Counties = new List<County>()
                };

                foreach (var itemCounty in itemCity.counties)
                {
                    city.Counties.Add(new County
                    {
                        Id = ObjectId.GenerateNewId(),
                        Name = itemCounty,
                        Latitude = "",
                        Longitude = "",
                        PostCode = ""
                    });
                }
                citiesCollection.InsertOne(city);
            }

            //var collection = database.GetCollection<Test>("Test");

            //var test = new Test()
            //{
            //    _Id = ObjectId.GenerateNewId(),
            //    NameSurname = "Ercan Ergin",
            //    Age = 29,
            //    AddressList = new List<Address>()
            //    {
            //        new Address
            //        {
            //            Title="Ev Adresim",
            //            Description="Tekirdağ"
            //        },
            //        new Address
            //        {
            //            Title="İş adresim",
            //            Description="İstanbul Kağıthane"
            //        }
            //    }
            //};

            //collection.InsertOne(test);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
