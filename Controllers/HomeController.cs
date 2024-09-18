using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AjaxBasicCRUDDemo.Models;

namespace AjaxBasicCRUDDemo.Controllers
{
    public class HomeController : Controller
    {
        private static List<Item> items = new List<Item>()
        {
            new Item {Id = 1, Name="Item 1", Description="Description 1", Price=10.00m},
            new Item {Id = 2, Name="Item 2", Description="Description 2", Price=20.00m},
        };

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllItems()
        {
            if (items.Count > 0)
            {
                return Json(items, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(500);
        }

        [HttpPost]
        public ActionResult Add(Item item)
        {
            item.Id = items.Max(i => i.Id) + 1;
            items.Add(item);
            return Json(item);
        }

        public ActionResult GetItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            var existingItem = items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
                existingItem.Price = item.Price;
            }
            return Json(existingItem);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            items.Remove(item);
            return Json(item);
        }
    }
}