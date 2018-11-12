using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.MVC.ViewModels.Usuarios
{
    public class UsuarioViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Login")]
        [MaxLength(Usuario.LoginMaxLength, ErrorMessage = "Login pode conter no máximo {0} caracteres")]
        [MinLength(Usuario.LoginMinLength, ErrorMessage = "Login tem que conter no mínimo {0} caracteres")]
        public String Login { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MaxLength(Usuario.SenhaMaxLength, ErrorMessage = "Senha pode conter no máximo {0} caracteres")]
        [MinLength(Usuario.SenhaMinLength, ErrorMessage = "Senha tem que conter no mínimo {0} caracteres")]
        public String Senha { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(Usuario.NomeMaxLength, ErrorMessage = "Nome pode conter no máximo {0} caracteres")]
        public String Nome { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail não é válido")]
        [MaxLength(Usuario.EmailMaxLength, ErrorMessage = "E-mail pode conter no máximo {0} caracteres")]
        public String Email { get; set; }

        public Boolean Status { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}
