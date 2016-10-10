using Business.Engine;
using Business.Repositories;
using Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace TBDplanner.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskEngine _taskEngine;
        private readonly ISubTaskEngine _subTaskEngine;
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskEngine taskEngine, ITaskRepository taskRepository, ISubTaskEngine subTaskEngine)
        {
            _taskEngine = taskEngine;
            _taskRepository = taskRepository;
            _subTaskEngine = subTaskEngine;
        }

        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Update(int id, string name)
        {
            var task = GetById(id);

            if(task != null)
            {
                var result = _taskEngine.Update(task);
                return Json(new { IsSuccess = true, Error = "", ReturnObject = result.ReturnObject });
            } else
            {
                return Json(new { IsSuccess = false, Error = "Could not find task" });
            }

   
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Add(Common.Models.Task task)
        {
            _taskEngine.Add(task);
            return Json(new { IsSuccess = false, Error = "testing", ReturnObject = "" });
        }

        public Common.Models.Task GetById(int id)
        {
            return _taskEngine.Get(id);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Get(int id)
        {
            var tasks = _taskEngine.Get(id);
            return Json(new { IsSuccess = false, Error = "testing", ReturnObject = tasks }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAll(int id)
        {
            List<Common.Models.Task> desiralizedTasks = _taskEngine.GetAll(id);
            var tasks = JsonConvert.SerializeObject(desiralizedTasks,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

            return Content(tasks, "application/json");
            //return Json(new { IsSuccess = false, Error = "testing", ReturnObject = { tasks: _tasks, subtasks: subtasks }, JsonRequestBehavior.AllowGet);
        }

        //var subtasks = _subTaskEngine.GetAll(id);
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetSubtasks(int taskId)
        {
            var subtasks = _subTaskEngine.GetAll(taskId);


            return Json(new
            {
                Subtasks = subtasks
            }, JsonRequestBehavior.AllowGet);
            //return Json(new { IsSuccess = false, Error = "testing", ReturnObject = { tasks: _tasks, subtasks: subtasks }, JsonRequestBehavior.AllowGet);
        }
    }
}