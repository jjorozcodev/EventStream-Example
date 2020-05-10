using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SSE_Demo_Async.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task SSE(string name)
        {
            Response.ContentType = "text/event-stream";

            Response.Write(string.Format("data: Connected at> {0}\n\n", DateTime.Now.ToString()));
            Response.Flush();

            DateTime startDate = DateTime.Now;
            while (startDate.AddMinutes(1) > DateTime.Now)
            {
                if (!Response.IsClientConnected)
                {
                    break;
                }

                await PoolTimer.SyncEvent();

                Response.Write(string.Format("data: {0} Server time> {1}\n\n", name, DateTime.Now.ToString()));
                Response.Flush();
            }
            
            Response.Close();
        }

    }
}