using Dashboard.WPF.Services;
using Dashboard.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Dashboard.WPF.Controllers
{
    public class FuncionariosController
    {
        public bool IsSuccessStatus { get; private set; }
        public string Message { get; private set; }
        private HttpClient _httpClient;
        private FuncionarioViewModel _funcionarioViewModel;

        public FuncionariosController()
        {
            _httpClient = DASHBOARD_API.Get();
        }

        public FuncionarioViewModel Index(int? id)
        {
            _funcionarioViewModel = new FuncionarioViewModel();
            IsSuccessStatus = true;

            if (id != null)
            {
                HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/funcionarios/{id}")
                                                        .Result;

                if (!responseGetById.IsSuccessStatusCode)
                {
                    IsSuccessStatus = false;
                    Message = "Não foi possível carregar o funcionario.";
                    return null;
                }

                _funcionarioViewModel = responseGetById.Content.ReadAsAsync<FuncionarioViewModel>().Result;
            }

            HttpResponseMessage responseGetAll = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/funcionarios/")
                                                    .Result;

            if (!responseGetAll.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar os funcionarios.";
                return null;
            }

            _funcionarioViewModel.FuncionariosViewModel = responseGetAll.Content.ReadAsAsync<IEnumerable<FuncionarioViewModel>>().Result;
            return _funcionarioViewModel;
        }

        public FuncionarioViewModel Adicionar(FuncionarioViewModel funcionarioViewModel)
        {
            _funcionarioViewModel = new FuncionarioViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/funcionarios/", funcionarioViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível adicionar o funcionario";
                return null;
            }

            _funcionarioViewModel = response.Content.ReadAsAsync<FuncionarioViewModel>().Result;
            Message = "Funcionario adicionado com sucesso";
            return _funcionarioViewModel;
        }

        public FuncionarioViewModel Atualizar(FuncionarioViewModel funcionarioViewModel)
        {
            _funcionarioViewModel = new FuncionarioViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PutAsJsonAsync(_httpClient.BaseAddress + $"/funcionarios/", funcionarioViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível atualizar o funcionario";
                return null;
            }

            Message = "Funcionario atualizado com sucesso";
            return funcionarioViewModel;
        }

        public void Remover(int id)
        {
            IsSuccessStatus = true;
            HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/funcionarios/{id}")
                                                        .Result;

            if (!responseGetById.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "O funcionario não existe";
            }

            HttpResponseMessage responseRemove = _httpClient
                                            .DeleteAsync(_httpClient.BaseAddress + $"/funcionarios/{id}")
                                            .Result;

            if (!responseRemove.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível remover o funcionario";
            }
            else
            {
                Message = "Funcionario removido com sucesso";
            }
        }

        public FuncionarioViewModel Validar(Dictionary<string, string> funcionarioDictionary)
        {
            _funcionarioViewModel = new FuncionarioViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                                .PostAsJsonAsync(_httpClient.BaseAddress + $"/funcionarios/valid", funcionarioDictionary)
                                                 .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = response.Content.ReadAsStringAsync().Result;
                return null;
            }

            _funcionarioViewModel = response.Content.ReadAsAsync<FuncionarioViewModel>().Result;
            return _funcionarioViewModel;
        }
    }
}
