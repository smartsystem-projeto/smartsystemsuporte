using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Entities;
using AutoMapper;
using Dashboard.MVC.ViewModels.Chamados;
using System;
using System.Net.Http;

namespace Dashboard.MVC.Controllers
{
    public class TiposChamadoController : Controller
    {
        private HttpClient _httpClient;
        private TipoChamadoViewModel _tipoChamadoViewModel;

        public TiposChamadoController([FromServices]IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("DASHBOARD_API");
            _tipoChamadoViewModel = new TipoChamadoViewModel();
        }

        // GET: TiposChamado
        public IActionResult Index(int? id)
        {
            _tipoChamadoViewModel.FormAction = "adicionar";

            if (id != null)
            {
                HttpResponseMessage respostaGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/tiposchamado/{id}")
                                                        .Result;

                if (!respostaGetById.IsSuccessStatusCode)
                    return NotFound();

                _tipoChamadoViewModel = respostaGetById.Content.ReadAsAsync<TipoChamadoViewModel>().Result;
                _tipoChamadoViewModel.FormAction = "editar";
            }

            HttpResponseMessage respostaGetAll = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/tiposchamado/")
                                                    .Result;

            if (!respostaGetAll.IsSuccessStatusCode)
                return NotFound();

            _tipoChamadoViewModel.TiposChamadoViewModel = respostaGetAll
                                                    .Content.ReadAsAsync<IEnumerable<TipoChamadoViewModel>>()
                                                    .Result;
            return View(_tipoChamadoViewModel);
        }

        // POST: TiposChamado/Adicionar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar([Bind("Descricao,Prioridade")] TipoChamadoViewModel tipoChamadoViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            HttpResponseMessage resposta = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/tiposchamado/", tipoChamadoViewModel)
                                            .Result;

            if (!resposta.IsSuccessStatusCode)
            {
                ViewBag.mensagemErro = "Não foi possível adicionar o Tipo de chamado";
                return RedirectToAction(nameof(Index));
            }

            _tipoChamadoViewModel = resposta.Content.ReadAsAsync<TipoChamadoViewModel>().Result;
            ViewBag.mensagemSucesso = "Tipo de chamado adicionado com sucesso";
            return RedirectToAction(nameof(Index), new { id = _tipoChamadoViewModel.TipoChamadoId });
        }

        // POST: TiposChamado/Editar/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar([Bind("TipoChamadoId,Descricao,Prioridade")] TipoChamadoViewModel tipoChamadoViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            HttpResponseMessage resposta = _httpClient
                                            .PutAsJsonAsync(_httpClient.BaseAddress + $"/tiposchamado/", tipoChamadoViewModel)
                                            .Result;

            if (!resposta.IsSuccessStatusCode)
                ViewBag.mensagemErro = "Não foi possível atualizar o Tipo de chamado";
            else
                ViewBag.mensagemSucesso = "Tipo de chamado atualizado com sucesso";

            return RedirectToAction(nameof(Index), new { id = tipoChamadoViewModel.TipoChamadoId });
        }

        // POST: TiposChamado/Remover/id
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public IActionResult RemoverConfirmado(int id)
        {
            HttpResponseMessage respostaGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/tiposchamado/{id}")
                                                        .Result;

            if (!respostaGetById.IsSuccessStatusCode)
                return NotFound();

            HttpResponseMessage respostaRemove = _httpClient
                                            .DeleteAsync(_httpClient.BaseAddress + $"/tiposchamado/{id}")
                                            .Result;

            if (!respostaRemove.IsSuccessStatusCode)
                ViewBag.mensagemErro = "Não foi possível remover o Tipo de chamado";
            else
                ViewBag.mensagemSucesso = "Tipo de chamado removido com sucesso";

            return RedirectToAction(nameof(Index));
        }
    }
}
