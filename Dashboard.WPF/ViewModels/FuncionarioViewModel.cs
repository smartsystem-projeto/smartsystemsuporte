using System;
using System.Collections.Generic;

namespace Dashboard.WPF.ViewModels
{
    public class FuncionarioViewModel
    {
        public int FuncionarioId { get; set; }

        public bool Status { get; set; }

        public string NomeTratamento { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public string CPF { get; set; }

        public List<TelefoneViewModel> Telefones { get; set; }

        public UsuarioViewModel Usuario { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public IEnumerable<FuncionarioViewModel> FuncionariosViewModel { get; set; }
    }
}
