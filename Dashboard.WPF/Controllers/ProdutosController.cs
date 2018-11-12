using Dashboard.WPF.Services;
using Dashboard.WPF.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Dashboard.WPF.Controllers
{
    public class ProdutosController
    {
        public bool IsSuccessStatus { get; private set; }
        public string Message { get; private set; }
        private HttpClient _httpClient;
        private ProdutoViewModel _produtoViewModel;

        public ProdutosController()
        {
            _httpClient = DASHBOARD_API.Get();
        }

        public ProdutoViewModel Index(int? id)
        {
            _produtoViewModel = new ProdutoViewModel();
            IsSuccessStatus = true;

            if (id != null)
            {
                HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/produtos/{id}")
                                                        .Result;

                if (!responseGetById.IsSuccessStatusCode)
                {
                    IsSuccessStatus = false;
                    Message = "Não foi possível carregar o produto.";
                    return null;
                }

                string contentGetById = responseGetById.Content.ReadAsStringAsync().Result;
                _produtoViewModel = JsonConvert.DeserializeObject<ProdutoViewModel>(contentGetById);
            }

            HttpResponseMessage responseGetAll = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/produtos/")
                                                    .Result;

            if (!responseGetAll.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar os produtos.";
                return null;
            }

            string contentGetAll = responseGetAll.Content.ReadAsStringAsync().Result;
            _produtoViewModel.ProdutosViewModel = JsonConvert.DeserializeObject<IEnumerable<ProdutoViewModel>>(contentGetAll);
            return _produtoViewModel;
        }

        public ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel)
        {
            _produtoViewModel = new ProdutoViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/produtos/", produtoViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível adicionar o produto";
                return null;
            }

            _produtoViewModel = response.Content.ReadAsAsync<ProdutoViewModel>().Result;
            Message = "Produto adicionado com sucesso";
            return _produtoViewModel;
        }

        public ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel)
        {
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PutAsJsonAsync(_httpClient.BaseAddress + $"/produtos/", produtoViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível atualizar o produto";
                return null;
            }

            Message = "Produto atualizado com sucesso";
            return produtoViewModel;
        }

        public void Remover(int id)
        {
            IsSuccessStatus = true;
            HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/produtos/{id}")
                                                        .Result;

            if (!responseGetById.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "O produto não existe";
            }

            HttpResponseMessage responseRemove = _httpClient
                                            .DeleteAsync(_httpClient.BaseAddress + $"/produtos/{id}")
                                            .Result;

            if (!responseRemove.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível remover o produto";
            }
            else
            {
                Message = "Produto removido com sucesso";
            }
        }

        public ProdutoViewModel Validar(Dictionary<string, string> produtoDictionary)
        {
            _produtoViewModel = new ProdutoViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                                .PostAsJsonAsync(_httpClient.BaseAddress + $"/produtos/valid", produtoDictionary)
                                                 .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = response.Content.ReadAsStringAsync().Result;
                return null;
            }

            _produtoViewModel = response.Content.ReadAsAsync<ProdutoViewModel>().Result;
            return _produtoViewModel;
        }
    }
}
