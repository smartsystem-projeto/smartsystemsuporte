using Dashboard.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.MVC.ViewModels.Chamados
{
    public class AbrirViewModel
    {
        [Key]
        [Display(Name = "Nº")]
        public int ChamadoId { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessage = "Preencha o campo produto")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public SelectList Produtos { get; set; }

        [Required(ErrorMessage = "Preencha o campo tipo")]
        [Display(Name = "Tipo")]
        public int TipoChamadoId { get; set; }
        [Display(Name = "Tipo")]
        public TipoChamado TipoChamado { get; set; }
        public SelectList TiposChamado { get; set; }

        [Required(ErrorMessage = "Preencha o campo assunto")]
        [Display(Name = "Assunto")]
        public int AssuntoChamadoId { get; set; }
        [Display(Name = "Assunto")]
        public AssuntoChamado AssuntoChamado { get; set; }
        public SelectList AssuntosChamado { get; set; }

        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(Chamado.DescricaoMaxLength, ErrorMessage = "Descrição pode conter no máximo {0} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }

        [Display(Name = "Último posicionamento")]
        public DateTime? UltimoPosicionamento { get; set; }

        public List<PosicionamentoChamado> PosicionamentosChamado { get; set; }

        [Required(ErrorMessage = "Selecione um cliente")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public SelectList Clientes { get; set; }

        [Display(Name = "Funcionário")]
        public int? FuncionarioId { get; set; }
        [Display(Name = "Funcionário")]
        public Funcionario Funcionario { get; set; }
        public SelectList Funcionarios { get; set; }

        [Display(Name = "Abertura")]
        public DateTime DataAbertura { get; set; }

        [Display(Name = "Última atualização")]
        public DateTime? DataAtualizacao { get; set; }
    }
}
