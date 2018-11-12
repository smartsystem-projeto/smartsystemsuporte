using Dashboard.WPF.Services;
using Dashboard.WPF.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Dashboard.WPF.Controllers
{
    public class ChamadosController
    {
        public bool IsSuccessStatus { get; private set; }
        public string Message { get; private set; }
        private HttpClient _httpClient;
        private ChamadoViewModel _chamadoViewModel;
        private PosicionamentoChamadoViewModel _posicionamentoChamadoViewModel;

        public ChamadosController()
        {
            _httpClient = DASHBOARD_API.Get();
        }

        public ChamadoViewModel Index(Dictionary<string, bool> filtros = null)
        {
            _chamadoViewModel = new ChamadoViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = new HttpResponseMessage();

            if (UsuarioAutal.Nivel == "Coordenador")
            {
                response = _httpClient
                                .GetAsync(_httpClient.BaseAddress + $"/chamados/")
                                .Result;
            }
            else
            {
                string funcionarioId = UsuarioAutal.FuncionarioId.ToString();
                response = _httpClient
                                .GetAsync(_httpClient.BaseAddress + $"/chamados/emaberto/funcionario/" + funcionarioId)
                                .Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar os chamados.";
                return null;
            }

            _chamadoViewModel.ChamadosViewModel = response.Content.ReadAsAsync<IEnumerable<ChamadoViewModel>>().Result;

            if (filtros != null)
                if (filtros["ApenasSemTecnico"])
                    _chamadoViewModel.ChamadosViewModel = _chamadoViewModel.ChamadosViewModel
                        .Where(chamado => chamado.FuncionarioId == null).ToList();

            return _chamadoViewModel;
        }

        public ChamadoViewModel Chamado(int id)
        {
            _chamadoViewModel = new ChamadoViewModel();
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                                .GetAsync(_httpClient.BaseAddress + $"/chamados/{id}")
                                                .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível carregar o chamado.";
                return null;
            }

            _chamadoViewModel = response.Content.ReadAsAsync<ChamadoViewModel>().Result;

            if (UsuarioAutal.Nivel.Equals("Coordenador"))
            {
                HttpResponseMessage responseFuncionarios = _httpClient
                                                        .GetAsync(_httpClient.BaseAddress + $"/funcionarios/")
                                                        .Result;

                if (!responseFuncionarios.IsSuccessStatusCode)
                {
                    IsSuccessStatus = false;
                    Message = "Não foi possível carregar os funcionários.";
                    return null;
                }

                _chamadoViewModel.FuncionariosViewModel = responseFuncionarios.Content.ReadAsAsync<IEnumerable<FuncionarioViewModel>>().Result;
            }

            return _chamadoViewModel;
        }

        public void AtualizarFuncionarioId(int chamadoId, int funcionarioId)
        {
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .GetAsync(_httpClient.BaseAddress + $"/chamados/{chamadoId}/funcionario/{funcionarioId}")
                                            .Result;

            if (response.IsSuccessStatusCode)
            {
                IsSuccessStatus = true;
            }
            else
            {
                IsSuccessStatus = false;
            }

            Message = response.Content.ReadAsStringAsync().Result;
        }

        public void AtualizarStatus(int chamadoId, string status)
        {
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .GetAsync(_httpClient.BaseAddress + $"/chamados/{chamadoId}/status/{status}")
                                            .Result;

            if (response.IsSuccessStatusCode)
            {
                IsSuccessStatus = true;
            }
            else
            {
                IsSuccessStatus = false;
            }

            Message = response.Content.ReadAsStringAsync().Result;
        }

        public void AdicionarPosicionamento(PosicionamentoChamadoViewModel posicionamentoChamadoViewModel)
        {
            IsSuccessStatus = true;
            HttpResponseMessage response = _httpClient
                                            .PostAsJsonAsync(_httpClient.BaseAddress + $"/posicionamentoschamado/", posicionamentoChamadoViewModel)
                                            .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = "Não foi possível adicionar o posicionamento";
                return;
            }

            Message = "Posicionamento adicionado com sucesso";
        }

        public PosicionamentoChamadoViewModel ValidarPosicionamento(Dictionary<string, string> posicionamentoChamadoDictionary)
        {
            _posicionamentoChamadoViewModel = new PosicionamentoChamadoViewModel();
            IsSuccessStatus = true;
            posicionamentoChamadoDictionary["FuncionarioId"] = UsuarioAutal.FuncionarioId.ToString();
            HttpResponseMessage response = _httpClient
                                                .PostAsJsonAsync(_httpClient.BaseAddress + $"/posicionamentoschamado/valid", posicionamentoChamadoDictionary)
                                                 .Result;

            if (!response.IsSuccessStatusCode)
            {
                IsSuccessStatus = false;
                Message = response.Content.ReadAsStringAsync().Result;
                return null;
            }

            _posicionamentoChamadoViewModel = response.Content.ReadAsAsync<PosicionamentoChamadoViewModel>().Result;
            return _posicionamentoChamadoViewModel;
        }
    }
}
