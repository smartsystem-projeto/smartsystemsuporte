using Dashboard.WPF.Services;
using Dashboard.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Dashboard.WPF.Controllers
{
    public class ContaController
    {
        public bool IsSuccessStatus { get; private set; }
        public string Message { get; private set; }
        private HttpClient _httpClient;

        public ContaController()
        {
            _httpClient = DASHBOARD_API.Get();
        }

        public void Entrar(string login, string senha)
        {
            IsSuccessStatus = true;

            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(senha))
            {
                IsSuccessStatus = false;
                Message = ".";
                return;
            }

            Dictionary<string, string> loginDictionary = new Dictionary<string, string>();
            loginDictionary["Login"] = login;
            loginDictionary["Senha"] = senha;
            HttpResponseMessage response = _httpClient
                                                .PostAsJsonAsync(_httpClient.BaseAddress + $"/usuarios/login/", loginDictionary)
                                                 .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = response.Content.ReadAsStringAsync().Result;
                return;
            }

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;

            if (usuarioViewModel.ClienteId != null)
            {
                IsSuccessStatus = false;
                Message = "Acesso permitido apenas para funcionários";
                return;
            }

            UsuarioAutal.UsuarioId = usuarioViewModel.UsuarioId;
            UsuarioAutal.Login = usuarioViewModel.Login;
            UsuarioAutal.Nome = usuarioViewModel.Nome;
            UsuarioAutal.Senha = usuarioViewModel.Senha;
            UsuarioAutal.Nivel = usuarioViewModel.Nivel;
            UsuarioAutal.FuncionarioId = Convert.ToInt32(usuarioViewModel.FuncionarioId);


        }
    }
}
