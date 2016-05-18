using Business.Context;
using Business.Engine;
using Business.Repositories;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TBDplanner.Infrastructure;

namespace TBDplanner.App_Start
{
    public static class IoCConfig
    {
        public static void UnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            registerEngine(container);
            registerRepository(container);
            registerContext(container);

            DependencyResolver.SetResolver(new UnityResolver(container));
        }

        public static void registerEngine(IUnityContainer container)
        {
            container.RegisterType<IUserEngine, UserEngine>();
        }

        public static void registerRepository(IUnityContainer container)
        {
            container.RegisterType<IUserRepository, UserRepository>();
        }

        public static void registerContext(IUnityContainer container)
        {
            container.RegisterType<UserContext, UserContext>();
        }
    }
}
