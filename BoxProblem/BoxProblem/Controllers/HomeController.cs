using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoxProblem.Models;
using BoxProblem.Data;
using BoxProblem.Services;

namespace BoxProblem.Controllers
{
    public class HomeController : Controller
    {
        private BoxInventoryService service;

        public HomeController(ApplicationDbContext context)
        {
            service = new BoxInventoryService(context);
        }
        public IActionResult Index()
        {
            return View(new List<BoxInventory>());
        }
        public IActionResult Add()
        {
            return View();
        }
       
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BoxInventory toAdd)
        {
            if (ModelState.IsValid)
            {
                toAdd.CreatedAt = DateTime.Now;

                service.AddBoxInventory(toAdd);
                return RedirectToAction("Index");
            }

            return View(toAdd);
        }
    }
}
