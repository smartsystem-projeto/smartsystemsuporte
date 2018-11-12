using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dashboard.Domain.Entities;
using Dashboard.MVC.Services;
using Dashboard.MVC.ViewModels.Chamados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dashboard.MVC.Controllers
{
    public class ChamadosController : Controller
    {
        private HttpClient _httpClient;

        public ChamadosController([FromServices]IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("DASHBOARD_API");
        }

        // GET: chamados
        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            HttpResponseMessage response = new HttpResponseMessage();

            if (UsuarioAutal.GetClienteId(HttpContext) != null)
            {
                string clienteId = UsuarioAutal.GetClienteId(HttpContext).ToString();
                response = _httpClient
                                .GetAsync(_httpClient.BaseAddress + $"/chamados/emaberto/cliente/" + clienteId)
                                .Result;
            }
            else if (UsuarioAutal.GetFuncionarioId(HttpContext) != null)
            {
                string funcionarioId = UsuarioAutal.GetFuncionarioId(HttpContext).ToString();
                response = _httpClient
                                .GetAsync(_httpClient.BaseAddress + $"/chamados/emaberto/funcionario/" + funcionarioId)
                                .Result;
            }

            if (!response.IsSuccessStatusCode)
                return NotFound();

            indexViewModel.Chamados = response.Content.ReadAsAsync<IEnumerable<Chamado>>().Result;

            return View(indexViewModel);
        }

        // GET: chamados/chamado/{id}
        public IActionResult Chamado(int id)
        {
            ChamadoViewModel chamadoViewModel = new ChamadoViewModel();
            HttpResponseMessage response = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/chamados/{id}")
                                                    .Result;

            if (!response.IsSuccessStatusCode)
                return NotFound();

            chamadoViewModel.Chamado = response
                                    .Content.ReadAsAsync<Chamado>()
                                    .Result;

            chamadoViewModel.ChamadoId = chamadoViewModel.Chamado.ChamadoId;
            chamadoViewModel.ClienteId = chamadoViewModel.Chamado.ClienteId;
            return View(chamadoViewModel);
        }

        // POST: chamados/chamado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Chamado([Bind("ChamadoId,ClienteId,Descricao,Chamado")] ChamadoViewModel chamadoViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            PosicionamentoChamado posicionamentoChamado = new PosicionamentoChamado
            {
                ChamadoId = chamadoViewModel.ChamadoId,
                ClienteId = chamadoViewModel.ClienteId,
                Descricao = chamadoViewModel.Descricao
            };
            HttpResponseMessage response = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/posicionamentoschamado/", posicionamentoChamado)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.mensagemErro = "Não foi possível adicionar o posicionamento";
                return View(chamadoViewModel);
            }

            posicionamentoChamado = response.Content.ReadAsAsync<PosicionamentoChamado>().Result;
            ViewBag.mensagemSucesso = "Posicionamento adicionado com sucesso";
            return RedirectToAction(nameof(Chamado), new { id = posicionamentoChamado.ChamadoId });
        }

        // GET: chamados/abrir
        public IActionResult Abrir()
        {
            AbrirViewModel abrirViewModel = new AbrirViewModel();
            //Get produtos
            HttpResponseMessage responseGetProdutos = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/produtos/")
                                                    .Result;

            if (!responseGetProdutos.IsSuccessStatusCode)
                return NotFound();

            IEnumerable<Produto> produtos = responseGetProdutos
                                                    .Content.ReadAsAsync<IEnumerable<Produto>>()
                                                    .Result;
            abrirViewModel.Produtos = new SelectList(produtos, "ProdutoId", "Nome");

            //Get tipos
            HttpResponseMessage responseGetTiposChamado = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/tiposchamado/")
                                                    .Result;

            if (!responseGetTiposChamado.IsSuccessStatusCode)
                return NotFound();

            IEnumerable<TipoChamado> tiposChamado = responseGetTiposChamado
                                                    .Content.ReadAsAsync<IEnumerable<TipoChamado>>()
                                                    .Result;
            abrirViewModel.TiposChamado = new SelectList(tiposChamado, "TipoChamadoId", "Descricao");

            //Get assuntos
            HttpResponseMessage responseGetAssuntosChamado = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/assuntoschamado/")
                                                    .Result;

            if (!responseGetAssuntosChamado.IsSuccessStatusCode)
                return NotFound();

            IEnumerable<AssuntoChamado> assuntosChamado = responseGetAssuntosChamado
                                                    .Content.ReadAsAsync<IEnumerable<AssuntoChamado>>()
                                                    .Result;
            abrirViewModel.AssuntosChamado = new SelectList(assuntosChamado, "AssuntoChamadoId", "Descricao");

            return View(abrirViewModel);
        }

        // POST: chamados/abrir
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Abrir([Bind("ProdutoId,TipoChamadoId,AssuntoChamadoId,Descricao")] AbrirViewModel abrirViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            Chamado chamado = new Chamado
            {
                Status = Status.Recebido,
                ClienteId = Convert.ToInt32(UsuarioAutal.GetClienteId(HttpContext)),
                ProdutoId = abrirViewModel.ProdutoId,
                TipoChamadoId = abrirViewModel.TipoChamadoId,
                AssuntoChamadoId = abrirViewModel.AssuntoChamadoId,
                Descricao = abrirViewModel.Descricao
            };
            HttpResponseMessage response = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/chamados/", chamado)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.mensagemErro = "Não foi possível abrir o chamado";
                return View(abrirViewModel);
            }

            chamado = response.Content.ReadAsAsync<Chamado>().Result;
            ViewBag.mensagemSucesso = "Chamado aberto com sucesso";
            return RedirectToAction(nameof(Chamado), new { id = chamado.ChamadoId });
        }
    }
}