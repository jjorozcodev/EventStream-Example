using System.Web;
using System.Web.Mvc;

namespace SSE_Demo_Async
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
