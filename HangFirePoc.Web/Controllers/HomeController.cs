using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Hangfire;

namespace HangFirePoc.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void DoSomething()
        {
            var backgroundJobClient = new BackgroundJobClient();

            backgroundJobClient.Enqueue(() => Debug.Print("Test"));
        }
    }
}