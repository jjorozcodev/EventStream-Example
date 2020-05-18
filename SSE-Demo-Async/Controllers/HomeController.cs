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
            
            while (true)
            {
                if (!Response.IsClientConnected)
                {
                    break;
                }

                string resp = await PoolTimer.GetServerTime(name);

                Response.Write(resp + "\n\n");
                Response.Flush();
            }
            
            Response.Close();
        }

    }
}