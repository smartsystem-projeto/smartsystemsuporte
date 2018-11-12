using System;
using System.Collections.Generic;

namespace Dashboard.WPF.ViewModels
{
    public class TipoChamadoViewModel
    {
        public int TipoChamadoId { get; set; }

        public string Descricao { get; set; }

        public int Prioridade { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public IEnumerable<TipoChamadoViewModel> TiposChamadoViewModel { get; set; }
    }
}
