using System;
using System.Collections.Generic;
using System.Net.Http;
using Dashboard.Domain.Entities;
using Dashboard.MVC.ViewModels.Conta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.MVC.Controllers
{
    public class ContaController : Controller
    {
        private HttpClient _httpClient;

        public ContaController([FromServices]IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("DASHBOARD_API");
        }

        // GET: conta/entrar
        public IActionResult Entrar()
        {
            return View();
        }

        // POST: conta/login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Entrar([Bind("Login,Senha")] EntrarViewModel entrarViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            Dictionary<string, string> loginDictionary = new Dictionary<string, string>();
            loginDictionary["Login"] = entrarViewModel.Login;
            loginDictionary["Senha"] = entrarViewModel.Senha;

            HttpResponseMessage response = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/usuarios/login/", loginDictionary)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.mensagemErro = "Não foi possível entrar na conta";
                return RedirectToAction(nameof(Entrar));
            }

            Usuario usuario = new Usuario();
            usuario = response.Content.ReadAsAsync<Usuario>().Result;
            HttpContext.Session.SetInt32("UsuarioId", usuario.UsuarioId);
            HttpContext.Session.SetString("Login", usuario.Login);
            HttpContext.Session.SetString("Senha", usuario.Senha);
            HttpContext.Session.SetString("Nome", usuario.Nome);
            HttpContext.Session.SetString("Nivel", usuario.Nivel);

            if (usuario.ClienteId != null)
                HttpContext.Session.SetInt32("ClienteId", Convert.ToInt32(usuario.ClienteId));

            if (usuario.FuncionarioId != null)
                HttpContext.Session.SetInt32("FuncionarioId", Convert.ToInt32(usuario.FuncionarioId));

            return RedirectToAction("index", "chamados");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UsuarioId");
            HttpContext.Session.Remove("Login");
            HttpContext.Session.Remove("Senha");
            HttpContext.Session.Remove("Nome");
            HttpContext.Session.Remove("Nivel");
            HttpContext.Session.Remove("ClienteId");
            HttpContext.Session.Remove("FuncionarioId");

            return RedirectToAction("entrar");
        }
    }
}