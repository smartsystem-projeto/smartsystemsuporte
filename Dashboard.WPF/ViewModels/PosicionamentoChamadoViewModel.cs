using System;

namespace Dashboard.WPF.ViewModels
{
    public class PosicionamentoChamadoViewModel
    {
        public int PosicionamentoChamadoId { get; set; }

        public string Descricao { get; set; }

        public int ChamadoId { get; set; }

        public int? ClienteId { get; set; }

        public int? FuncionarioId { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
