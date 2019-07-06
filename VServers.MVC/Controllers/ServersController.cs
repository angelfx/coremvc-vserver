using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VServers.MVC.Models;

namespace VServers.MVC.Controllers
{
    public class ServersController : Controller
    {
        private VServers.Abstract.ILogic _logic;
        private TableVirtualServerViewModel model;

        public ServersController(VServers.Abstract.ILogic logic)
        {
            _logic = logic;
            model = new TableVirtualServerViewModel(_logic);
        }

        // GET: Servers
        public ActionResult Index()
        {
            return View(model);
        }

        // GET: Servers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Servers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servers/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                model.AddServer();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Servers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Servers/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteAll()
        {
            try
            {
                // TODO: Add update logic here
                model.RemoveServers();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Servers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Servers/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                model.MarkToDelete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}