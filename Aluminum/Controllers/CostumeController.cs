using System.Web.Mvc;

namespace Aluminum.Controllers
{
    public class CostumeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}