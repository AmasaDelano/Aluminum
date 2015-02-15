using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Aluminum.Models;
using Aluminum.ViewModels;

namespace Aluminum.Controllers
{
    public class CostumeController : Controller
    {
        private readonly CostumeService _costumeService;
        private readonly MembershipService _membershipService;

        public CostumeController(CostumeService costumeService, MembershipService membershipService)
        {
            _costumeService = costumeService;
            _membershipService = membershipService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            RemoveAuthTicket();

            return RedirectToAction("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(UserViewModel user, string returnUrl)
        {
            if (user != null && ModelState.IsValid)
            {
                bool logInSuccessful = _membershipService.LogIn(user);

                if (logInSuccessful)
                {
                    CreateAuthTicket(user);

                    return Redirect(returnUrl);
                }
            }

            return RedirectToAction("LogIn");
        }

        private void CreateAuthTicket(UserViewModel user)
        {
            var ticket = new FormsAuthenticationTicket(
                name: user.UserName,
                isPersistent: false,
                timeout: 90);

            string cookieString = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieString);

            Response.Cookies.Add(cookie);
        }

        private void RemoveAuthTicket()
        {
            FormsAuthentication.SignOut();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Admin()
        {
            var costumes = _costumeService.GetCostumes();

            return View(costumes);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddCostume()
        {
            return RedirectToAction("EditCostume");
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditCostume(short costumeId = 0)
        {
            var costume = _costumeService.GetCostume(costumeId);

            return View(costume);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteCostume(short costumeId)
        {
            _costumeService.DeleteCostume(costumeId);

            return RedirectToAction("Admin");
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditCostume(CostumeViewModel costume, HttpPostedFileBase imageFile)
        {
            if (costume != null && ModelState.IsValid)
            {
                _costumeService.SaveCostume(costume, imageFile, Server);

                TempData["SavedMessage"] = string.Format("{0} costume saved!", costume.Name);

                return RedirectToAction("Admin");
            }

            ModelState.AddModelError("name", "Each costume must have a name!");

            return RedirectToAction("EditCostume");
        }
    }
}