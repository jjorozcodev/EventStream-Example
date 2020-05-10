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

        public void SSE()
        {
            Response.ContentType = "text/event-stream";

            DateTime startDate = DateTime.Now;
            while (startDate.AddMinutes(1) > DateTime.Now)
            {
                if (!Response.IsClientConnected)
                {
                    break;
                }

                Response.Write(string.Format("data: {0}\n\n", DateTime.Now.ToString()));
                Response.Flush();

                System.Threading.Thread.Sleep(3000);
            }
            
            Response.Close();
        }

    }
}