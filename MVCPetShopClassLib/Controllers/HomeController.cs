using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVCPetShopClassLib.Models;
using PetShopLib.Interfaces;
using PetShopLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPetShopClassLib.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<PetShopProduct> _repo;
        public HomeController(ILogger<HomeController> logger, IRepository<PetShopProduct> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult PetShopDB()
        {
            var list = _repo.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult EditPetShopDB(int id)
        {
            var item = _repo.GetById(id);
            return View(item);
        }
        [HttpPost]
        public IActionResult EditPetShopDB(PetShopProduct product)
        {
            var item = _repo.GetById(product.ID);
            _repo.Update(product);
            return View("EditPetShopDB",item);
        }
        [HttpGet]
        public IActionResult CreatePetShopDB()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePetShopDB(PetShopProduct product)
        {
            _repo.Add(product);
            return View("PetShopDB",_repo.GetAll());
        }
        public IActionResult DetailsPetShopDB(int id)
        {
            var item = _repo.GetById(id);
            return View(item);

        }
        [HttpGet]
        public IActionResult DeletePetShopDB(int id)
        {
            var item = _repo.GetById(id);
            return View(item);
        }
        [HttpPost]
        public IActionResult DeletePetShopDB(PetShopProduct product)
        {
            _repo.DeleteById(product.ID);
            return View("PetShopDB", _repo.GetAll());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
