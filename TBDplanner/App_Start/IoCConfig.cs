using Business.Context;
using Business.Engine;
using Business.Repositories;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using TBDplanner.Controllers;

namespace TBDplanner.App_Start
{
    public static class IoCConfig
    {
        public static void WindsorContainer()
        {
            //container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            //container.RegisterType<IUserEngine, UserEngine>();
            //container.RegisterType<IUserRepository, UserRepository>();
            //container.RegisterType<UserContext, UserContext>();
        }
    }
}
