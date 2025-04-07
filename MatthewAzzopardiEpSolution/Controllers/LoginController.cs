using Microsoft.AspNetCore.Mvc;

namespace MatthewAzzopardiEpSolution.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                HttpContext.Session.SetString("Username", username);
                return RedirectToAction("AllPolls", "Poll");
            }

            ViewBag.Error = "Username is required.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
