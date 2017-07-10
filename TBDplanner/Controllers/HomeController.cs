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
        //private IContributorEngine _contributorEngine;
        public List<Helper> Contributors;
        // GET: Home

        public HomeController()
        {
            //_contributorEngine = contributorEngine;
        }
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

        public ActionResult Dashboard()
        {
            var token = Session["UserId"];
            var user = Session["UserName"];



            if (token != null)
            {
                TBDplanner.Models.Dashboard Dashboard = new Dashboard();
                //Dashboard.Contributors = _contributorEngine.GetAll(Convert.ToInt32(token));

                //Dashboard:36 Uncaught SyntaxError: Unterminated template literal (cant do it this way) 
                //Uncaught ReferenceError: userId is not defined
                return View(Dashboard);
            }

            else
                return RedirectToAction("Index", "Home");

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