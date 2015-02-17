using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Aluminum.Web.Models;
using Aluminum.Web.ViewModels;

namespace Aluminum.Web.Controllers
{
    public class CostumeController : Controller
    {
        public const string AdminMessageKey = "AdminMessage";

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
        public ActionResult Suggest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Suggest(string suggestion, string emailAddress)
        {
            if (!string.IsNullOrWhiteSpace(suggestion))
            {
                _costumeService.SendSuggestion(suggestion, emailAddress);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Suggest");
        }

        [HttpPost]
        [Authorize]
        public ActionResult HideSuggestion(long suggestionId)
        {
            _costumeService.HideSuggestion(suggestionId, User.Identity.Name);

            return RedirectToAction("Admin");
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

            return RedirectToAction("Index");
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

                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Admin");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
            }

            return RedirectToAction("LogIn");
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordViewModel changePassword)
        {
            bool changeSuccessful = _membershipService.ChangePassword(User.Identity.Name, changePassword);

            if (changeSuccessful)
            {
                TempData[AdminMessageKey] = "Password changed!";

                return RedirectToAction("Admin");
            }

            return RedirectToAction("ChangePassword");
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
            var adminScreen = new CostumeAdminScreenViewModel();
            adminScreen.Costumes = _costumeService.GetCostumes();
            adminScreen.Suggestions = _costumeService.GetSuggestions();

            return View(adminScreen);
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

                TempData[AdminMessageKey] = string.Format("{0} costume saved!", costume.Name);

                return RedirectToAction("Admin");
            }

            ModelState.AddModelError("name", "Each costume must have a name!");

            return RedirectToAction("EditCostume");
        }
    }
}