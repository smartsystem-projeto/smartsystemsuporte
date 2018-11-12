using System;
using System.Collections.Generic;

namespace Dashboard.WPF.ViewModels
{
    public class ClienteViewModel
    {
        public int ClienteId { get; set; }

        public bool Status { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public string CNPJ { get; set; }

        public string CPF { get; set; }

        public List<TelefoneViewModel> Telefones { get; set; }

        public string Email { get; set; }

        public int? TempoResposta { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public IEnumerable<ClienteViewModel> ClientesViewModel { get; set; }
    }
}
