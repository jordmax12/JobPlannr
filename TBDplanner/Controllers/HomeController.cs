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
            //UserEngine userEngine = new UserEngine();
            //UserAccounts user = new UserAccounts();
            //user.Username = "nancyRaegan";
            //user.Password = "Raegan23";
            //user.FirstName = "Nancy";
            //user.LastName = "Raegan";
            //user.Email = "nancy@raegan.com";
            //userEngine.Add(user);
            //userEngine.GetAll();
            return View();
        }
    }
}