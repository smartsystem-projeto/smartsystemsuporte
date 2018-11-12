using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dashboard.Domain.Entities;
using AutoMapper;
using Dashboard.MVC.ViewModels.Chamados;
using System;
using System.Net.Http;

namespace Dashboard.MVC.Controllers
{
    public class AssuntosChamadoController : Controller
    {
        private HttpClient _httpClient;
        private AssuntoChamadoViewModel _assuntoChamadoViewModel;

        public AssuntosChamadoController([FromServices]IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("DASHBOARD_API");
            _assuntoChamadoViewModel = new AssuntoChamadoViewModel();
        }

        // GET: AssuntosChamado
        public IActionResult Index(int? id)
        {
            _assuntoChamadoViewModel.FormAction = "adicionar";

            if (id != null)
            {
                HttpResponseMessage respostaGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/assuntoschamado/{id}")
                                                        .Result;

                if (!respostaGetById.IsSuccessStatusCode)
                    return NotFound();

                _assuntoChamadoViewModel = respostaGetById.Content.ReadAsAsync<AssuntoChamadoViewModel>().Result;
                _assuntoChamadoViewModel.FormAction = "editar";
            }

            HttpResponseMessage respostaGetAll = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/assuntoschamado/")
                                                    .Result;

            if (!respostaGetAll.IsSuccessStatusCode)
                return NotFound();

            _assuntoChamadoViewModel.AssuntosChamadoViewModel = respostaGetAll
                                                    .Content.ReadAsAsync<IEnumerable<AssuntoChamadoViewModel>>()
                                                    .Result;
            HttpResponseMessage respostaGetAllTiposChamados = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/tiposchamado/")
                                                    .Result;

            if (!respostaGetAllTiposChamados.IsSuccessStatusCode)
                return NotFound();

            IEnumerable<TipoChamadoViewModel> tiposChamadoViewModel = respostaGetAllTiposChamados
                                                    .Content.ReadAsAsync<IEnumerable<TipoChamadoViewModel>>()
                                                    .Result;
            _assuntoChamadoViewModel.TiposChamadoViewModel = new SelectList(tiposChamadoViewModel, "TipoChamadoId", "Descricao");
            return View(_assuntoChamadoViewModel);
        }

        // POST: AssuntosChamado/Adicionar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar([Bind("Descricao,TipoChamadoId")] AssuntoChamadoViewModel assuntoChamadoViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            HttpResponseMessage resposta = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/assuntoschamado/", assuntoChamadoViewModel)
                                            .Result;

            if (!resposta.IsSuccessStatusCode)
            {
                ViewBag.mensagemErro = "Não foi possível adicionar o Assunto de chamado";
                return RedirectToAction(nameof(Index));
            }

            _assuntoChamadoViewModel = resposta.Content.ReadAsAsync<AssuntoChamadoViewModel>().Result;
            ViewBag.mensagemSucesso = "Assunto de chamado adicionado com sucesso";
            return RedirectToAction(nameof(Index), new { id = _assuntoChamadoViewModel.AssuntoChamadoId });
        }

        // POST: AssuntosChamado/Editar/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar([Bind("AssuntoChamadoId,Descricao,TipoChamadoId")] AssuntoChamadoViewModel assuntoChamadoViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            HttpResponseMessage resposta = _httpClient
                                            .PutAsJsonAsync(_httpClient.BaseAddress + $"/assuntoschamado/", assuntoChamadoViewModel)
                                            .Result;

            if (!resposta.IsSuccessStatusCode)
                ViewBag.mensagemErro = "Não foi possível atualizar o Assunto de chamado";
            else
                ViewBag.mensagemSucesso = "Assunto de chamado atualizado com sucesso";

            return RedirectToAction(nameof(Index), new { id = assuntoChamadoViewModel.AssuntoChamadoId });
        }

        // POST: AssuntosChamado/Remover/id
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            HttpResponseMessage respostaGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/assuntoschamado/{id}")
                                                        .Result;

            if (!respostaGetById.IsSuccessStatusCode)
                return NotFound();

            HttpResponseMessage respostaRemove = _httpClient
                                            .DeleteAsync(_httpClient.BaseAddress + $"/assuntoschamado/{id}")
                                            .Result;

            if (!respostaRemove.IsSuccessStatusCode)
                ViewBag.mensagemErro = "Não foi possível remover o Assunto de chamado";
            else
                ViewBag.mensagemSucesso = "Assunto de chamado removido com sucesso";

            return RedirectToAction(nameof(Index));
        }
    }
}
