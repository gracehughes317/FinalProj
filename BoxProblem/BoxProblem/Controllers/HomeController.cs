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

        public IActionResult Index(List<BoxInventory> model = null, bool doSearch = false)
        {
            if (!doSearch)
            {
                return View(service.GetAllBoxInventorys());
            }
            else
            {
                return View(model);
            }
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Details(int id)
        {
            BoxInventory box = service.GetBoxInventoryById(id);
            return View(box);
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

        [HttpPost]
        public ActionResult Index(string toSearch, string search)
        {
            if (search.ToLower() == "inventorycount")
            {
                return View(service.FilterCount(Int32.Parse(toSearch)));
            }
            else if (CostBox == true)
            {
                return View(service.FilterCost(toSearch));
            }
            else if (VolumeBox == true)
            {
                return View(service.FilterVolume((int)toSearch));
            }
            else if (WeightBox == true)
            {
                return View(service.FilterWeight((int)toSearch));
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            BoxInventory box = service.GetBoxInventoryById(id);
            return View(box);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoxInventory box)
        {
            if (ModelState.IsValid)
            {
                service.SaveEdits(box);
                return RedirectToAction("Index");
            }
            return View(box);
        }

        public ActionResult Delete(int id)
        {
            BoxInventory box = service.GetBoxInventoryById(id);
            return View(box);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoxInventory box = service.GetBoxInventoryById(id);
            service.DeleteBoxInventory(box);
            return RedirectToAction("Index");
        }
    }
}

        
            else if (search.ToLower() == "costbox")
            {
                return View(service.FilterCost(Double.Parse(toSearch)));
            else if (search.ToLower() == "volumebox")
            {
                return View(service.FilterVolume(Int32.Parse(toSearch)));
            }
            else if (search.ToLower() == "weightbox")
            {
                return View(service.FilterWeight(Int32.Parse(toSearch)));
            }
            else if (search.ToLower() == "liquidbox")
            {
                return View(service.FilterCanHoldLiquid(Boolean.Parse(toSearch)));
            }
            else
            {
                return View();