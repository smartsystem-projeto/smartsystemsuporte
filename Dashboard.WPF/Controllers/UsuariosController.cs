using Dashboard.WPF.Services;
using Dashboard.WPF.ViewModels;
using System.Collections.Generic;
using System.Net.Http;

namespace Dashboard.WPF.Controllers
{
    public class UsuariosController
    {
        public bool IsSuccessStatus { get; private set; }
        public string Message { get; private set; }
        private HttpClient _httpClient;
        private UsuarioViewModel _usuarioViewModel;

        public UsuariosController()
        {
            _httpClient = DASHBOARD_API.Get();
        }

        public UsuarioViewModel Index(int? id)
        {
            _usuarioViewModel = new UsuarioViewModel();
            IsSuccessStatus = true;

            if (id != null)
            {
                HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/usuarios/{id}")
                                                        .Result;

                if (!responseGetById.IsSuccessStatusCode)
                {
                    IsSuccessStatus = false;
                    Message = "Não foi possível carregar o usuário.";
                    return null;
                }

                _usuarioViewModel = responseGetById.Content.ReadAsAsync<UsuarioViewModel>().Result;
            }

            HttpResponseMessage responseGetAll = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/usuarios/")
                                                    .Result;

            if (!responseGetAll.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar os usuários.";
                return null;
            }

            _usuarioViewModel.UsuariosViewModel = responseGetAll.Content.ReadAsAsync<IEnumerable<UsuarioViewModel>>().Result;
            HttpResponseMessage responseClientes = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/clientes/")
                                                    .Result;

            if (!responseClientes.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar os clientes.";
                return null;
            }

            _usuarioViewModel.ClientesViewModel = responseClientes.Content.ReadAsAsync<IEnumerable<ClienteViewModel>>().Result;
            HttpResponseMessage responseFuncionarios = _httpClient
                                                    .GetAsync(_httpClient.BaseAddress + $"/funcionarios/")
                                                    .Result;

            if (!responseFuncionarios.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar os funcionários.";
                return null;
            }

            _usuarioViewModel.FuncionariosViewModel = responseFuncionarios.Content.ReadAsAsync<IEnumerable<FuncionarioViewModel>>().Result;

            return _usuarioViewModel;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel)
        {
            _usuarioViewModel = new UsuarioViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/usuarios/", usuarioViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível adicionar o usuário";
                return null;
            }

            _usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
            Message = "Usuário adicionado com sucesso";
            return _usuarioViewModel;
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel)
        {
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PutAsJsonAsync(_httpClient.BaseAddress + $"/usuarios/", usuarioViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível atualizar o usuário";
                return null;
            }

            Message = "Usuário atualizado com sucesso";
            return usuarioViewModel;
        }

        public void Remover(int id)
        {
            IsSuccessStatus = true;
            HttpResponseMessage responseGetById = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/usuarios/{id}")
                                                        .Result;

            if (!responseGetById.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "O usuário não existe";
            }

            HttpResponseMessage responseRemove = _httpClient
                                            .DeleteAsync(_httpClient.BaseAddress + $"/usuarios/{id}")
                                            .Result;

            if (!responseRemove.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível remover o usuário";
            }
            else
            {
                Message = "Usuário removido com sucesso";
            }
        }

        public UsuarioViewModel Validar(Dictionary<string, string> clienteDictionary)
        {
            _usuarioViewModel = new UsuarioViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                                .PostAsJsonAsync(_httpClient.BaseAddress + $"/usuarios/valid", clienteDictionary)
                                                 .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = response.Content.ReadAsStringAsync().Result;
                return null;
            }

            _usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
            return _usuarioViewModel;
        }
    }
}
