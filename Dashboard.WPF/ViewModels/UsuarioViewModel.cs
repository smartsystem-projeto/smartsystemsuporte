using System;
using System.Collections.Generic;

namespace Dashboard.WPF.ViewModels
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Nivel { get; set; }

        public int? FuncionarioId { get; set; }

        public int? ClienteId { get; set; }

        public int? Acessos { get; set; }
        public DateTime? UltimoAcesso { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public IEnumerable<UsuarioViewModel> UsuariosViewModel { get; set; }

        public IEnumerable<ClienteViewModel> ClientesViewModel { get; set; }

        public IEnumerable<FuncionarioViewModel> FuncionariosViewModel { get; set; }
    }
}
