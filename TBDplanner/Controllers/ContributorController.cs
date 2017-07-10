using Business.Context;
using Business.Engine;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TBDplanner.Controllers
{
    public class ContributorController : Controller
    {
        private readonly BusinessContext _businessContext;
        //private readonly IContributorEngine _contributorEngine;

        public ContributorController(BusinessContext businessContext)
        {
            //_contributorEngine = contributorEngine;
            _businessContext = businessContext;
        }
        // GET: Contributor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(int id)
        {
            //var planners = _contributorEngine.GetAll(id);
            // return Json(new { IsSuccess = false, Error = "testing", ReturnObject = planners }, JsonRequestBehavior.AllowGet);
            return Json(new { IsSuccess = false, Error = "testing", ReturnObject = "1" }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult AddContributor(Helper user)
        {
            try
            {
                using (_businessContext)
                {
                    //_contributorEngine.Add(user);
                    _businessContext.SaveChanges();
                }

                return Json(new { IsSuccess = true, Error = "", ReturnObject = user });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Error = ex.Message, ReturnObject = "" });
            }
        }
    }
}