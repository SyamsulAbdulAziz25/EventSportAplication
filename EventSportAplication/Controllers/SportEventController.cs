using SportEvent.Controllers;
using SportEvent.Core;
using SportEvent.Core.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventSportAplication.Controllers
{
    public class SportEventController : Controller
    {
        // GET: SportEvent

        private readonly ISportEventBussinesLayer sportEventBussinesLayer;

        public SportEventController(ISportEventBussinesLayer sportEventBussinesLayer)
        {
            this.sportEventBussinesLayer = sportEventBussinesLayer;
        }
        // GET: SportEvent
        public ActionResult Index()
        {
            return View(sportEventBussinesLayer.GetActiveEvents());
        }
        public ActionResult ViewAllData()
        {
            return View(sportEventBussinesLayer.GetActiveAllEvents());
        }

        // GET: SportEvent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SportEvent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SportEvent/Create
        [HttpPost]
        public ActionResult Create(Event ev)
        {
            try
            {
                // TODO: Add insert logic here
                sportEventBussinesLayer.InsertUser(ev);

                return RedirectToAction("ViewAllData");
            }
            catch
            {
                return View();
            }
        }

        // GET: SportEvent/Edit/5
        public ActionResult Edit(String id)
        {
            // var eventStatus = new EventStatus();
            return View(sportEventBussinesLayer.FindUser(id));
        }

        // POST: SportEvent/Edit/5
        [HttpPost]
        public ActionResult Edit(SportEventOutput sportEventOutput)
        {
            //try
            //{
            // TODO: Add update logic here
            sportEventBussinesLayer.UpdateUser(sportEventOutput);

            return RedirectToAction("ViewAllData");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: SportEvent/Delete/5
        public ActionResult Delete(String id)
        {
            return View(sportEventBussinesLayer.FindUserForDelete(id));
        }

        // POST: SportEvent/Delete/5
        [HttpPost]
        public ActionResult Delete(String id, Event dataEvent)
        {
            try
            {
                sportEventBussinesLayer.DeleteUser(id);

                return RedirectToAction("ViewAllData");
            }
            catch
            {
                return View();
            }
        }
    }
}