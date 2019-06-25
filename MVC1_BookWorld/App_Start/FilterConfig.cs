using System.Web;
using System.Web.Mvc;

namespace MVC1_BookWorld
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); //authorization to access
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
