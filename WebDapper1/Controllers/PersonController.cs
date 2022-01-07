using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

using WebDapper1.Models;
using WebDapper1.Models.DomainModel;
using WebDapper1.Models.Service;

namespace WebDapper1.Controllers
{
    public class PersonController : Controller
    {
        PersonService service = new PersonService();
        AccountEFModel db = new AccountEFModel();
        

        // GET: Person
        public ActionResult Index()
        {
            var data = service.GetAll();
            return View(data);
        }

        //// GET: Person/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            try
            {
                // TODO: Add insert logic here
                service.Create(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var data = service.Get(id);
            return View(data);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,PersonModel model)
        {
            try
            {
                // TODO: Add update logic here
                service.Update(id,model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var data = service.Get(id);
            return View(data);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                service.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Login()
        {
            return View();
        }


        //[HttpPost]

        //public ActionResult Login(string Account,string Password)
        //{
        //    var account = db.Logins.Where(m=>m.Account == Account && m.Password == Password).FirstOrDefault();
        //    if (account == null)
        //    {
        //        ViewBag.Message="帳號密碼錯誤";
        //        return RedirectToAction("Index");
        //    }
        //    Session["Weclome"]=account.Account+"歡迎";
        //    Session["account"]=account;

        //    return RedirectToAction("Index");
        //}

        [HttpPost]

        public ActionResult Login(Login model)
        {
            var account = service.Login(model);
            if (account == null)
            {
                ViewBag.Message = "帳號密碼錯誤";
                return RedirectToAction("Index");
            }
            Session["Weclome"] = account.Account + "歡迎";
            Session["account"] = account;

            return RedirectToAction("Index");
        }

    } 
}
