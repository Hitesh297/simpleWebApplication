using Common.Application;
using Project.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
            {ViewBag.Title = StringHelper.WelcomeUser("Guest");}
            else
            {ViewBag.Title = StringHelper.WelcomeUser(System.Web.HttpContext.Current.User.Identity.Name.Split('\\').Last());}
            ViewBag.Date = Helper.DisplayDateTime();
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
