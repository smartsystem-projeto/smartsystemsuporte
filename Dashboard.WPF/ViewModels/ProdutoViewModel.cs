using System;
using System.Collections.Generic;

namespace Dashboard.WPF.ViewModels
{
    public class ProdutoViewModel
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public IEnumerable<ProdutoViewModel> ProdutosViewModel { get; set; }
    }
}
