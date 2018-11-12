using Dashboard.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.MVC.ViewModels.Conta
{
    public class EntrarViewModel
    {
        [Required(ErrorMessage = "Preencha o campo login")]
        [MaxLength(Usuario.LoginMaxLength, ErrorMessage = "Login pode conter no máximo {0} caracteres")]
        [MinLength(Usuario.LoginMinLength, ErrorMessage = "Login tem que conter no mínimo {0} caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Preencha o campo senha")]
        [MaxLength(Usuario.SenhaMaxLength, ErrorMessage = "Senha pode conter no máximo {0} caracteres")]
        [MinLength(Usuario.SenhaMinLength, ErrorMessage = "Senha tem que conter no mínimo {0} caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
