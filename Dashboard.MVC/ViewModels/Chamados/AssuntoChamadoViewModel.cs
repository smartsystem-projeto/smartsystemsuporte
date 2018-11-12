using Dashboard.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.MVC.ViewModels.Chamados
{
    public class AssuntoChamadoViewModel
    {
        [Key]
        public int AssuntoChamadoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(AssuntoChamado.DescricaoMaxLength, ErrorMessage = "Descrição pode conter no máximo {0} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tipo de chamado")]
        [Display(Name = "Tipo de chamado")]
        public int TipoChamadoId { get; set; }
        [Display(Name = "Tipo de chamado")]
        public TipoChamado TipoChamado { get; set; }

        [Display(Name = "Adicionado")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Última atualização")]
        public DateTime? DataAtualizacao { get; set; }

        public IEnumerable<AssuntoChamadoViewModel> AssuntosChamadoViewModel { get; set; }

        public SelectList TiposChamadoViewModel { get; set; }

        public String FormAction { get; set; }
    }
}
