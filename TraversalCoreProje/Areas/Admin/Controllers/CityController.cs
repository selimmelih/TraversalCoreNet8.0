﻿using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult GetCityById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            if (values == null)
            {

            }
            else
            {
                var jsonValues = JsonConvert.SerializeObject(values);
                return Json(jsonValues);

            }
            return View();
        }
        public IActionResult DeleteCity(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            _destinationService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            //var values = _destinationService.TGetByID(destination.DestinationID);
            _destinationService.TUpdate(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }
        //statik bir liste örneği
        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID =1,
        //        CityName = "Üsküp",
        //        CityCountry = "Makedonya"
        //    },
        //    new CityClass
        //    {
        //        CityID =2,
        //        CityName = "Roma",
        //        CityCountry = "İtalya"
        //    },
        //    new CityClass
        //    {
        //        CityID =3,
        //        CityName = "Londra",
        //        CityCountry = "İngiltere"
        //    },
        //};
    }
}
