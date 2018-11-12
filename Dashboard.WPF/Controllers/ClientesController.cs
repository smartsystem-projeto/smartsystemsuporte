using Dashboard.WPF.Services;
using Dashboard.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Dashboard.WPF.Controllers
{
    public class ClientesController
    {
        public bool IsSuccessStatus { get; private set; }
        public string Message { get; private set; }
        private HttpClient _httpClient;
        private ClienteViewModel _clienteViewModel;

        public ClientesController()
        {
            _httpClient = DASHBOARD_API.Get();
        }

        public ClienteViewModel Index(int? id)
        {
            _clienteViewModel = new ClienteViewModel();
            IsSuccessStatus = true;

            if (id != null)
            {
                HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/clientes/{id}")
                                                        .Result;

                if (!responseGetById.IsSuccessStatusCode)
                {
                    IsSuccessStatus = false;
                    Message = "Não foi possível carregar o cliente.";
                    return null;
                }

                _clienteViewModel = responseGetById.Content.ReadAsAsync<ClienteViewModel>().Result;
            }

            HttpResponseMessage responseGetAll = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/clientes/")
                                                    .Result;

            if (!responseGetAll.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar os clientes.";
                return null;
            }

            _clienteViewModel.ClientesViewModel = responseGetAll.Content.ReadAsAsync<IEnumerable<ClienteViewModel>>().Result;
            return _clienteViewModel;
        }

        public ClienteViewModel Adicionar(ClienteViewModel clienteViewModel)
        {
            _clienteViewModel = new ClienteViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/clientes/", clienteViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível adicionar o cliente";
                return null;
            }

            _clienteViewModel = response.Content.ReadAsAsync<ClienteViewModel>().Result;
            Message = "Cliente adicionado com sucesso";
            return _clienteViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            _clienteViewModel = new ClienteViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PutAsJsonAsync(_httpClient.BaseAddress + $"/clientes/", clienteViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível atualizar o cliente";
                return null;
            }

            Message = "Cliente atualizado com sucesso";
            return clienteViewModel;
        }

        public void Remover(int id)
        {
            IsSuccessStatus = true;
            HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/clientes/{id}")
                                                        .Result;

            if (!responseGetById.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "O cliente não existe";
            }

            HttpResponseMessage responseRemove = _httpClient
                                            .DeleteAsync(_httpClient.BaseAddress + $"/clientes/{id}")
                                            .Result;

            if (!responseRemove.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível remover o cliente";
            }
            else
            {
                Message = "Cliente removido com sucesso";
            }
        }

        public ClienteViewModel Validar(Dictionary<string, string> clienteDictionary)
        {
            _clienteViewModel = new ClienteViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                                .PostAsJsonAsync(_httpClient.BaseAddress + $"/clientes/valid", clienteDictionary)
                                                 .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = response.Content.ReadAsStringAsync().Result;
                return null;
            }

            _clienteViewModel = response.Content.ReadAsAsync<ClienteViewModel>().Result;
            return _clienteViewModel;
        }
    }
}
