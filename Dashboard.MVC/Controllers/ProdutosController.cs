using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboard.MVC.ViewModels.Produtos;
using System.Net.Http;

namespace Dashboard.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private HttpClient _httpClient;
        private ProdutoViewModel _produtoViewModel;

        public ProdutosController([FromServices]IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("DASHBOARD_API");
            _produtoViewModel = new ProdutoViewModel();
        }

        // GET: Produtos
        public IActionResult Index(int? id)
        {
            _produtoViewModel.FormAction = "adicionar";

            if (id != null)
            {
                HttpResponseMessage respostaGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/produtos/{id}")
                                                        .Result;

                if (!respostaGetById.IsSuccessStatusCode)
                    return NotFound();

                _produtoViewModel = respostaGetById.Content.ReadAsAsync<ProdutoViewModel>().Result;
                _produtoViewModel.FormAction = "editar";
            }

            HttpResponseMessage respostaGetAll = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/produtos/")
                                                    .Result;

            if (!respostaGetAll.IsSuccessStatusCode)
                return NotFound();

            _produtoViewModel.ProdutosViewModel = respostaGetAll
                                                    .Content.ReadAsAsync<IEnumerable<ProdutoViewModel>>()
                                                    .Result;
            return View(_produtoViewModel);
        }

        // POST: Produtos/Adicionar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar([Bind("Nome,Descricao")] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            HttpResponseMessage resposta = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/produtos/", produtoViewModel)
                                            .Result;

            if (!resposta.IsSuccessStatusCode)
            {
                ViewBag.mensagemErro = "Não foi possível adicionar o Produto";
                return RedirectToAction(nameof(Index));
            }

            _produtoViewModel = resposta.Content.ReadAsAsync<ProdutoViewModel>().Result;
            ViewBag.mensagemSucesso = "Produto adicionado com sucesso";
            return RedirectToAction(nameof(Index), new { id = _produtoViewModel.ProdutoId });
        }

        // POST: Produtos/Editar/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar([Bind("ProdutoId,Nome,Descricao")] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            HttpResponseMessage resposta = _httpClient
                                            .PutAsJsonAsync(_httpClient.BaseAddress + $"/produtos/", produtoViewModel)
                                            .Result;

            if (!resposta.IsSuccessStatusCode)
                ViewBag.mensagemErro = "Não foi possível atualizar o Produto";
            else
                ViewBag.mensagemSucesso = "Produto atualizado com sucesso";

            return RedirectToAction(nameof(Index), new { id = produtoViewModel.ProdutoId });
        }

        // POST: Produtos/Remover/id
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public IActionResult RemoverConfirmado(int id)
        {
            HttpResponseMessage respostaGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/produtos/{id}")
                                                        .Result;

            if (!respostaGetById.IsSuccessStatusCode)
                return NotFound();

            HttpResponseMessage respostaRemove = _httpClient
                                            .DeleteAsync(_httpClient.BaseAddress + $"/produtos/{id}")
                                            .Result;

            if (!respostaRemove.IsSuccessStatusCode)
                ViewBag.mensagemErro = "Não foi possível remover o Produto";
            else
                ViewBag.mensagemSucesso = "Produto removido com sucesso";

            return RedirectToAction(nameof(Index));
        }
    }
}
