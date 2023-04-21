using System.Web.Mvc;
using System.Web.Routing;

namespace BuildingConferenceRoomInfo.WebAjax
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            // Web API routes
            routes.MapRoute(
                name: "ActionApi",
                url: "api/{controller}/{action}/{id}",
                defaults: new { id = UrlParameter.Optional }
            );
        }
    }
}
