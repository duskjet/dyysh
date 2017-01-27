using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Dyysh.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            await HttpContext.Authentication.SignInAsync("MyCookieMiddlewareInstance", HttpContext.User);
            HttpContext.Session.Set("username", System.Text.Encoding.Unicode.GetBytes("pidor"));

            return RedirectToAction("Index", "Home");
        }
    }
}
