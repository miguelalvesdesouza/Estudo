using Aspc_Session1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aspc_Session1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("SessionNome", "Macoratti");
            HttpContext.Session.SetInt32("SessionIdade", 54);
            var userInfo = new User()
            {
                Id = 1,
                Nome = "Macoratti"
            };
            HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(userInfo));

            return View();
        }
    }
}
