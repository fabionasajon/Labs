using System.Web;
using System.Web.Mvc;

namespace MVC_Angular_Bootstrap.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
