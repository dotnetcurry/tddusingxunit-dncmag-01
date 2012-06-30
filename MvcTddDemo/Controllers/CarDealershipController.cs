using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTddDemo.Models;

namespace MvcTddDemo.Controllers
{
    public class CarDealershipController : Controller
    {
        private ICarDealershipRepository repository;

        public CarDealershipController(
            ICarDealershipRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult List()
        {
            var cars = repository.GetAllCars();
            return View("List", cars);
        }
    }

}
