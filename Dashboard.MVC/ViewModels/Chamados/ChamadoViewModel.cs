using Dashboard.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.MVC.ViewModels.Chamados
{
    public class ChamadoViewModel
    {
        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(PosicionamentoChamado.DescricaoMaxLength, ErrorMessage = "Descrição pode conter no máximo {0} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo chamado")]
        public int ChamadoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo cliente")]
        public int ClienteId { get; set; }

        public Chamado Chamado { get; set; }
    }
}
