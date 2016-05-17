using Business.Engine;
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
        // GET: Home
        public ActionResult Index()
        {
            UserEngine userEngine = new UserEngine();
            User user = new User();
            user.username = "Nancy";
            user.password = "Raegan";
            userEngine.Add(user);
            userEngine.GetAll();
            return View();
        }
    }
}