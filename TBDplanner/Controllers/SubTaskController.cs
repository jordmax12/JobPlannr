using Business.Engine;
using Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TBDplanner.Controllers
{
    public class SubTaskController : Controller
    {
        private readonly ISubTaskEngine _subTaskEngine;
        private readonly ISubTaskRepository _subTaskRepository;

        public SubTaskController(ISubTaskEngine subTaskEngine, ISubTaskRepository subTaskRepository)
        {
            _subTaskEngine = subTaskEngine;
            _subTaskRepository = subTaskRepository;
        }

        // GET: SubTask
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Update(int id, string name)
        {
            var subTask = GetById(id);

            if (subTask != null)
            {
                var result = _subTaskEngine.Update(subTask);
                return Json(new { IsSuccess = true, Error = "", ReturnObject = result.ReturnObject });
            }
            else
            {
                return Json(new { IsSuccess = false, Error = "Could not find sub task" });
            }


        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Add(Common.Models.SubTask subTask)
        {
            var _subTask = _subTaskEngine.AddWithReturn(subTask);
            return Json(new { IsSuccess = false, Error = "testing", ReturnObject = new { Id = _subTask.Id } });
        }

        public Common.Models.SubTask GetById(int id)
        {
            return _subTaskEngine.Get(id);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Get(int id)
        {
            var tasks = _subTaskEngine.Get(id);
            return Json(new { IsSuccess = false, Error = "testing", ReturnObject = tasks }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAll(int id)
        {
            var tasks = _subTaskEngine.GetAll(id);
            return Json(new { IsSuccess = false, Error = "testing", ReturnObject = tasks }, JsonRequestBehavior.AllowGet);
        }
    }
}