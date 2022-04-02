using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestesRastreabilidade.Models;
using TestesRastreabilidade.Repository;

namespace TestesRastreabilidade.Controllers
{
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public void ChecarLogin()
        {
            var usuario = new LoginModel();
            usuario.Usuario = Request.Form["usuario"];
            usuario.Senha = Request.Form["senha"];
            var loginRepository = new LoginRepository();
            if(loginRepository.Get(usuario.Usuario, usuario.Senha))
            {
                Response.Redirect("/Home/Index");
            }
            
        }
    }
}
