using Business.Engine;
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
    [Authorize]
    public class PlannerController : Controller
    {
        private readonly IPlannerEngine _plannerEngine;
        public PlannerController(IPlannerEngine plannerEngine)
        {
            _plannerEngine = plannerEngine;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Add(Planner planner)
        {
            _plannerEngine.Add(planner);
            return Json(new { IsSuccess = false, Error = "testing", ReturnObject = "" });
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return new JsonResult();
        }

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
