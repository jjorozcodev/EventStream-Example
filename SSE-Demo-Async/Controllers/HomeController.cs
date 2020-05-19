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

        public void SSE(string name)
        {
            Response.ContentType = "text/event-stream";

            Response.Write(string.Format("data: Connected at> {0}\n\n", DateTime.Now.ToString()));
            Response.Flush();

            bool updated = false;
            DateTime timeToUpdate = PoolTimer.nextUpdate;

            while (true)
            {
                if (!Response.IsClientConnected)
                {
                    break;
                }
                
                if(DateTime.Now >= timeToUpdate && !updated)
                {
                    updated = true;
                    Response.Write("data: " + name + ", the time to update is> " + timeToUpdate.ToLongTimeString() + " at " + DateTime.Now.ToLongTimeString());
                    Response.Write("\n\n");
                    Response.Flush();
                }
                
                if (updated && timeToUpdate != PoolTimer.nextUpdate)
                {
                    updated = false;
                    timeToUpdate = PoolTimer.nextUpdate;
                }
            }

            Response.Close();
        }

    }
}