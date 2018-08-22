using Gerasite.Application.AutoMapper;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace Gerasite.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityConfig.RegisterTypes(new UnityContainer());
            AutoMapperConfig.RegisterMappings();
        }
    }
}
