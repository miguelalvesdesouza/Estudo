using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppRazor.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;


namespace AppRazor.Controllers
{
    public class ProdutosController : LoginController
    {
        public IActionResult Home()
        {
            if (HttpContext.Session.GetString("session") == "Authorized")
            {
                ViewBag.Produtos = "Lista de Produtos";
                var listaProdutos = new Produtos().GetProdutos();
                ViewBag.ListaProdutos = listaProdutos;
                return View();
            }
            else
            {
                return LocalRedirect("/Login/Index");
            }
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public void Salvar()
        {
            var produtos = new Produtos();
            produtos.Id = Convert.ToInt32("0" + Request.Form["id"]);
            produtos.Nome = Request.Form["nome"];
            produtos.Descricao = Request.Form["descricao"];
            produtos.Salvar(produtos);
            Response.Redirect("Home");
        }

        public void Deletar(int id)
        {
            var produtos = new Produtos();
            produtos.Deletar(id);
            Response.Redirect("/Produtos/Home");
        }

        public IActionResult Alterar(int id)
        {
            var produto = new Produtos();
            produto.GetProdutos(id);
            ViewBag.Produto = produto;
            return View();
        }

        public IActionResult Procurar()
        {
            try
            {
                var pesquisa = Request.Form["pesquisar"];
                var filtroNome = Request.Form["opcao"];
                var filtroDescricao = Request.Form["opcao"];
                var produtosPesquisa = new Produtos();
                produtosPesquisa.Procurar(pesquisa, filtroNome, filtroDescricao);
                if (filtroNome == "nome" || filtroDescricao == "descricao")
                {
                    ViewBag.ProdutosPesquisa = produtosPesquisa;
                }
                else
                {
                    ViewBag.ProdutosPesquisa = produtosPesquisa.GetProdutos();
                }
                return View();

            }
            catch
            {
                return NotFound();
            }
        }

    }
}
