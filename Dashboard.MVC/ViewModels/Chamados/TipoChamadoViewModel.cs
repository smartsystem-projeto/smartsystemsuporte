using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.MVC.ViewModels.Chamados
{
    public class TipoChamadoViewModel
    {
        [Key]
        public int TipoChamadoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(TipoChamado.DescricaoMaxLength, ErrorMessage = "Descrição pode conter no máximo {0} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Prioridade")]
        public int Prioridade { get; set; }

        public List<AssuntoChamado> AssuntosChamado { get; set; }

        [Display(Name = "Adicionado")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Última atualização")]
        public DateTime? DataAtualizacao { get; set; }

        public IEnumerable<TipoChamadoViewModel> TiposChamadoViewModel { get; set; }

        public String FormAction { get; set; }
    }
}
