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
            return View(service.GetAllBoxInventorys());
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
        public ActionResult Search(double ToSearch, bool InventoryBox, bool LiquidBox, bool CostBox, bool VolumeBox, bool WeightBox, DateTime DateCreated)
        {
            List<BoxInventory> BoxList = new List<BoxInventory>();
            if (InventoryBox == true)
            {
                BoxList = service.FilterCount((int)ToSearch);
               
            }
            else if (LiquidBox == true)
            {
                //BoxList = service.FilterCanHoldLiquid();
            }
            else if (CostBox == true)
            {
                BoxList = service.FilterCost(ToSearch);
            }
            else if (VolumeBox == true)
            {
                BoxList = service.FilterVolume((int)ToSearch);
            }
            else if (WeightBox == true)
            {
                BoxList = service.FilterWeight((int)ToSearch);
            }
            return View(BoxList);
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
