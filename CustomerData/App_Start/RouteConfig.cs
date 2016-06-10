using System.Web.Mvc;
using System.Web.Routing;

namespace CustomerData
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "TagFilter",
                url: "Home/TagFilter/{tag}",
                defaults: new { controller = "Home", action = "TagFilter", tag = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );


        }
    }
}
