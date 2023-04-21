using System.Web;
using System.Web.Mvc;

namespace BuildingConferenceRoomInfo.WebAjax
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
