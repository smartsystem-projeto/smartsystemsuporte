using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dashboard.Domain.Entities
{
    public class Chamado
    {
        public int ChamadoId { get; set; }

        public string Status { get; set; }
        public const int StatusMaxLength = 25;

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int TipoChamadoId { get; set; }
        public TipoChamado TipoChamado { get; set; }

        public int AssuntoChamadoId { get; set; }
        public AssuntoChamado AssuntoChamado { get; set; }

        public string Descricao { get; set; }
        public const int DescricaoMaxLength = 255;

        public string Responsavel { get; set; }
        public const int ResponsavelMaxLength = 7;

        public DateTime? UltimoPosicionamento { get; set; }

        public List<PosicionamentoChamado> PosicionamentosChamado { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public DateTime DataAbertura { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
