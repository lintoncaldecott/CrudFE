using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using CrudFE.Services;
namespace CrudFE
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            //container.RegisterType<IUserRequestClient>();
            //container.RegisterType<IApiDataService>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}