﻿using Business.Engine;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TBDplanner.Models;
namespace TBDplanner.Controllers
{
    public class HomeController : Controller
    {
        public string userIP;
        // GET: Home
        public ActionResult Index()
        {
            //UserEngine userEngine = new UserEngine();
            //UserAccounts user = new UserAccounts();
            //user.Username = "nancyRaegan";
            //user.Password = "Raegan23";
            //user.FirstName = "Nancy";
            //user.LastName = "Raegan";
            //user.Email = "nancy@raegan.com";
            //userEngine.Add(user);
            //userEngine.GetAll();
            TempData["userIP"] = Request.UserHostAddress;
            return View();
        }

        public JsonResult GetAuth()
        {
            var token = Session["UserId"];
            var user = Session["UserName"];

            if (token != null)
                return Json(new { name = $"Hello From Server Side {user}" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { name = "Not logged in" }, JsonRequestBehavior.AllowGet);
        }
    }
}