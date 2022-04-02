using AppRazor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppRazor.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void ChecarLogin()
        {
            var usuario = new Usuarios();
            usuario.Email = Request.Form["Email"];
            usuario.Senha = Request.Form["Senha"];

            if (usuario.Login())
            {
                HttpContext.Session.SetString("session", "Authorized");
                Response.Redirect("/Home/Index");
            }
            else
            {
                HttpContext.Session.SetString("session", "Unauthorized");
                Response.Redirect("/Login/Index");
            }
        }
    }
}
