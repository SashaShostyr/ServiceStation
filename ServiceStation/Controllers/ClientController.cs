using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using ServiceStation.Models;

namespace ServiceStation.Controllers
{
    public class ClientController: Controller
    {
        private ServiceStationContext db = new ServiceStationContext();

        [HttpGet]
        public ActionResult Index()
        {
            var clients = db.Clients.ToList();
            return View(clients);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Client client = db.Clients.Find(id);
            return View(client);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }
        public ActionResult Delete(int id)
        {
            Client user = db.Clients.Find(id);
            db.Clients.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}