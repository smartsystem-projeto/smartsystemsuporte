using System;
using System.Collections.Generic;

namespace Dashboard.WPF.ViewModels
{
    public class ChamadoViewModel
    {
        public int ChamadoId { get; set; }

        public string Status { get; set; }

        public int ProdutoId { get; set; }
        public ProdutoViewModel Produto { get; set; }

        public int TipoChamadoId { get; set; }
        public TipoChamadoViewModel TipoChamado { get; set; }

        public int AssuntoChamadoId { get; set; }
        public AssuntoChamadoViewModel AssuntoChamado { get; set; }

        public string Descricao { get; set; }

        public string Responsavel { get; set; }

        public DateTime? UltimoPosicionamento { get; set; }

        public List<PosicionamentoChamadoViewModel> PosicionamentosChamado { get; set; }

        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }

        public int? FuncionarioId { get; set; }
        public FuncionarioViewModel Funcionario { get; set; }

        public DateTime DataAbertura { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public IEnumerable<ChamadoViewModel> ChamadosViewModel { get; set; }

        public IEnumerable<FuncionarioViewModel> FuncionariosViewModel { get; set; }
    }
}
