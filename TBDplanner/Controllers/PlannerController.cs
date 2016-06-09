using Business.Engine;
using Business.Repositories;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace TBDplanner.Controllers
{
    
    public class PlannerController : Controller
    {
        private readonly IPlannerEngine _plannerEngine;
        private readonly IPlannerRepository _plannerRepository;
        public PlannerController(IPlannerEngine plannerEngine, IPlannerRepository plannerRepository)
        {
            _plannerEngine = plannerEngine;
            _plannerRepository = plannerRepository;
        }

        public ActionResult Detail(int id)
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Add(Planner planner)
        {
            _plannerEngine.Add(planner);
            return Json(new { IsSuccess = false, Error = "testing", ReturnObject = "" });
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Delete(Planner planner)
        {
            planner = _plannerEngine.Get(planner.Id);
            _plannerEngine.Delete(planner);
            return Json(new { IsSuccess = false, Error = "testing", ReturnObject = "" });
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Update()
        {
            return new JsonResult();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Get(int id)
        {
            var planners = _plannerEngine.GetAll(id);
            return Json(new { IsSuccess = false, Error = "testing", ReturnObject = planners }, JsonRequestBehavior.AllowGet);
        }
    }
}
