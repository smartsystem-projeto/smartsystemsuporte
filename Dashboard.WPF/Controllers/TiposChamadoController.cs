using Dashboard.WPF.Services;
using Dashboard.WPF.ViewModels;
using System.Collections.Generic;
using System.Net.Http;

namespace Dashboard.WPF.Controllers
{
    public class TiposChamadoController
    {
        public bool IsSuccessStatus { get; private set; }
        public string Message { get; private set; }
        private HttpClient _httpClient;
        private TipoChamadoViewModel _tipoChamadoViewModel;

        public TiposChamadoController()
        {
            _httpClient = DASHBOARD_API.Get();
        }

        public TipoChamadoViewModel Index(int? id)
        {
            _tipoChamadoViewModel = new TipoChamadoViewModel();
            IsSuccessStatus = true;

            if (id != null)
            {
                HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/tiposchamado/{id}")
                                                        .Result;

                if (!responseGetById.IsSuccessStatusCode)
                {
                    IsSuccessStatus = false;
                    Message = "Não foi possível carregar o tipo de chamado.";
                    return null;
                }

                _tipoChamadoViewModel = responseGetById.Content.ReadAsAsync<TipoChamadoViewModel>().Result;
            }

            HttpResponseMessage responseGetAll = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/tiposchamado/")
                                                    .Result;

            if (!responseGetAll.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar os tipos de chamado.";
                return null;
            }

            _tipoChamadoViewModel.TiposChamadoViewModel = responseGetAll.Content.ReadAsAsync<IEnumerable<TipoChamadoViewModel>>().Result;
            return _tipoChamadoViewModel;
        }

        public TipoChamadoViewModel Adicionar(TipoChamadoViewModel tipoChamadoViewModel)
        {
            _tipoChamadoViewModel = new TipoChamadoViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/tiposchamado/", tipoChamadoViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível adicionar o tipo de chamado";
                return null;
            }

            _tipoChamadoViewModel = response.Content.ReadAsAsync<TipoChamadoViewModel>().Result;
            Message = "Tipo de chamado adicionado com sucesso";
            return _tipoChamadoViewModel;
        }

        public TipoChamadoViewModel Atualizar(TipoChamadoViewModel tipoChamadoViewModel)
        {
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PutAsJsonAsync(_httpClient.BaseAddress + $"/tiposchamado/", tipoChamadoViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível atualizar o tipo de chamado";
                return null;
            }

            Message = "Tipo de chamado atualizado com sucesso";
            return tipoChamadoViewModel;
        }

        public void Remover(int id)
        {
            IsSuccessStatus = true;
            HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/tiposchamado/{id}")
                                                        .Result;

            if (!responseGetById.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "O tipo de chamado não existe";
            }

            HttpResponseMessage responseRemove = _httpClient
                                            .DeleteAsync(_httpClient.BaseAddress + $"/tiposchamado/{id}")
                                            .Result;

            if (!responseRemove.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível remover o tipo de chamado";
            }
            else
            {
                Message = "Tipo de chamado removido com sucesso";
            }
        }

        public TipoChamadoViewModel Validar(Dictionary<string, string> produtoDictionary)
        {
            _tipoChamadoViewModel = new TipoChamadoViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                                .PostAsJsonAsync(_httpClient.BaseAddress + $"/tiposchamado/valid", produtoDictionary)
                                                 .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = response.Content.ReadAsStringAsync().Result;
                return null;
            }

            _tipoChamadoViewModel = response.Content.ReadAsAsync<TipoChamadoViewModel>().Result;
            return _tipoChamadoViewModel;
        }
    }
}
