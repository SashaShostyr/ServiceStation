using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ServiceStation.Models;

namespace ServiceStation.Controllers
{
    public class RequestController : Controller
    {
        ServiceStationContext db = new ServiceStationContext();
        public ActionResult Index()
        {
       
            Client client = db.Clients.Where(m => m.Login == "admin").FirstOrDefault();

            var requests = db.Requests.Where(r => r.ClientId == client.Id)
                                    .Include(r => r.Lifecycle)  
                                    .Include(r => r.Client)        
                                    .OrderByDescending(r => r.Lifecycle.Opened);

            return View(requests.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            Client client = db.Clients.Where(m => m.Login == "admin").FirstOrDefault();
            if (client != null)
            {
                return View();
            }
            return RedirectToAction("LogOff", "Account");
        }

        [HttpPost]
        public ActionResult Create(Request request, HttpPostedFileBase error)
        {
            Client client = db.Clients.Where(m => m.Login == "admin").FirstOrDefault();
            if (client == null)
            {
                return RedirectToAction("LogOff", "Account");
            }
            if (ModelState.IsValid)
            {
                request.Status = (int)RequestStatus.Open;

                DateTime current = DateTime.Now;
                Lifecycle newLifecycle = new Lifecycle() { Opened = current };
                request.Lifecycle = newLifecycle;


                db.Lifecycles.Add(newLifecycle);

                request.ClientId = client.Id;


                db.Requests.Add(request);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(request);
        }
        public ActionResult Details(int id)
        {
            Request request = db.Requests.Find(id);

            if (request != null)
            {
                return PartialView("Details", request);
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            Request request = db.Requests.Find(id);
            Client client = db.Clients.Where(m => m.Login == "admin").First();
            if (request != null && request.ClientId == client.Id)
            {
                Lifecycle lifecycle = db.Lifecycles.Find(request.LifecycleId);
                db.Lifecycles.Remove(lifecycle);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult RequestList()
        {
            var requests = db.Requests.Include(r => r.Lifecycle)
                                    .Include(r => r.Client)
                                    .OrderByDescending(r => r.Lifecycle.Opened);

            return View(requests.ToList());
        }
	}
}