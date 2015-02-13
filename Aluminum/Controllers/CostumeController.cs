using System.Web;
using System.Web.Mvc;
using Aluminum.Models;
using Aluminum.ViewModels;

namespace Aluminum.Controllers
{
    public class CostumeController : Controller
    {
        private readonly CostumeService _costumeService;

        public CostumeController(CostumeService costumeService)
        {
            _costumeService = costumeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Admin()
        {
            var costumes = _costumeService.GetCostumes();

            return View(costumes);
        }

        [HttpPost]
        public ActionResult AddCostume()
        {
            return RedirectToAction("EditCostume");
        }

        [HttpGet]
        public ActionResult EditCostume(short costumeId = 0)
        {
            var costume = _costumeService.GetCostume(costumeId);

            return View(costume);
        }

        [HttpPost]
        public ActionResult DeleteCostume(short costumeId)
        {
            _costumeService.DeleteCostume(costumeId);

            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult EditCostume(CostumeViewModel costume, HttpPostedFileBase imageFile)
        {
            //if (imageFile != null && imageFile.ContentLength > 0)
            //{
            //    _costumeService.UploadFile(imageFile, costume.Name, Server);

            //    costume.ImageFileName = imageFile.FileName;
            //}

            _costumeService.SaveCostume(costume);

            TempData["SavedMessage"] = string.Format("{0} costume saved!", costume.Name);

            return RedirectToAction("Admin");
        }
    }
}