using System;
using System.Collections.Generic;

namespace Dashboard.WPF.ViewModels
{
    public class AssuntoChamadoViewModel
    {
        public int AssuntoChamadoId { get; set; }

        public string Descricao { get; set; }

        public int TipoChamadoId { get; set; }
        public TipoChamadoViewModel TipoChamado { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public IEnumerable<AssuntoChamadoViewModel> AssuntosChamadoViewModel { get; set; }

        public IEnumerable<TipoChamadoViewModel> TiposChamadoViewModel { get; set; }
    }
}
