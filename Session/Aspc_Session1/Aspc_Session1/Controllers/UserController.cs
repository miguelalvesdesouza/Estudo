using Aspc_Session1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aspc_Session1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var userInfo = JsonConvert.DeserializeObject<User>
               (HttpContext.Session.GetString("SessionUser"));

            return View(userInfo);
        }
    }
}