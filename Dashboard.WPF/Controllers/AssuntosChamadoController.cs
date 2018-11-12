using Dashboard.WPF.Services;
using Dashboard.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.WPF.Controllers
{
    public class AssuntosChamadoController
    {
        public bool IsSuccessStatus { get; private set; }
        public string Message { get; private set; }
        private HttpClient _httpClient;
        private AssuntoChamadoViewModel _assuntoChamadoViewModel;

        public AssuntosChamadoController()
        {
            _httpClient = DASHBOARD_API.Get();
        }

        public AssuntoChamadoViewModel Index(int? id)
        {
            _assuntoChamadoViewModel = new AssuntoChamadoViewModel();
            IsSuccessStatus = true;

            if (id != null)
            {
                HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/assuntoschamado/{id}")
                                                        .Result;

                if (!responseGetById.IsSuccessStatusCode)
                {
                    IsSuccessStatus = false;
                    Message = "Não foi possível carregar o assunto de chamado.";
                    return null;
                }

                _assuntoChamadoViewModel = responseGetById.Content.ReadAsAsync<AssuntoChamadoViewModel>().Result;
            }

            HttpResponseMessage responseGetAll = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/assuntoschamado/")
                                                    .Result;

            if (!responseGetAll.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar os assuntos de chamado.";
                return null;
            }

            _assuntoChamadoViewModel.AssuntosChamadoViewModel = responseGetAll.Content.ReadAsAsync<IEnumerable<AssuntoChamadoViewModel>>().Result;
            HttpResponseMessage responseTiposChamado = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/tiposchamado/")
                                                    .Result;

            if (!responseTiposChamado.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar os tipos de chamado.";
                return null;
            }

            _assuntoChamadoViewModel.TiposChamadoViewModel = responseTiposChamado.Content.ReadAsAsync<IEnumerable<TipoChamadoViewModel>>().Result;

            return _assuntoChamadoViewModel;
        }

        public AssuntoChamadoViewModel Adicionar(AssuntoChamadoViewModel assuntoChamadoViewModel)
        {
            _assuntoChamadoViewModel = new AssuntoChamadoViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/assuntoschamado/", assuntoChamadoViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível adicionar o assunto de chamado";
                return null;
            }

            _assuntoChamadoViewModel = response.Content.ReadAsAsync<AssuntoChamadoViewModel>().Result;
            Message = "Assunto de chamado adicionado com sucesso";
            return _assuntoChamadoViewModel;
        }

        public AssuntoChamadoViewModel Atualizar(AssuntoChamadoViewModel assuntoChamadoViewModel)
        {
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PutAsJsonAsync(_httpClient.BaseAddress + $"/assuntoschamado/", assuntoChamadoViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível atualizar o assunto de chamado";
                return null;
            }

            Message = "Assunto de chamado atualizado com sucesso";
            return assuntoChamadoViewModel;
        }

        public void Remover(int id)
        {
            IsSuccessStatus = true;
            HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/assuntoschamado/{id}")
                                                        .Result;

            if (!responseGetById.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "O assunto de chamado não existe";
            }

            HttpResponseMessage responseRemove = _httpClient
                                            .DeleteAsync(_httpClient.BaseAddress + $"/assuntoschamado/{id}")
                                            .Result;

            if (!responseRemove.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível remover o assunto de chamado";
            }
            else
            {
                Message = "Assunto de chamado removido com sucesso";
            }
        }

        public AssuntoChamadoViewModel Validar(Dictionary<string, string> produtoDictionary)
        {
            _assuntoChamadoViewModel = new AssuntoChamadoViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                                .PostAsJsonAsync(_httpClient.BaseAddress + $"/assuntoschamado/valid", produtoDictionary)
                                                 .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = response.Content.ReadAsStringAsync().Result;
                return null;
            }

            _assuntoChamadoViewModel = response.Content.ReadAsAsync<AssuntoChamadoViewModel>().Result;
            return _assuntoChamadoViewModel;
        }
    }
}
