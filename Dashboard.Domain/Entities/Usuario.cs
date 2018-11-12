using System;
using System.Collections.Generic;

namespace Dashboard.Domain.Entities
{
    public class Usuario : absValidationBase
    {
        public int UsuarioId { get; set; }

        public bool Status { get; set; }

        public string Login { get; set; }
        public const int LoginMinLength = 4;
        public const int LoginMaxLength = 16;

        public string Senha { get; set; }
        public const int SenhaMinLength = 4;
        public const int SenhaMaxLength = 50;

        public string Nome { get; set; }
        public const int NomeMaxLength = 50;

        public string Email { get; set; }
        public const int EmailMaxLength = 50;

        public string Nivel { get; set; }
        public const int NivelMaxLength = 20;

        public int? Acessos { get; set; }
        public DateTime? UltimoAcesso { get; set; }

        public int? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public void Valid(Dictionary<string, string> usuarioDictionary)
        {
            isValid = true;

            if (String.IsNullOrEmpty(usuarioDictionary["Login"]))
            {
                isValid = false;
                message = "Login é obrigatório.";
            }
            if (usuarioDictionary["Login"].Length  < LoginMinLength && usuarioDictionary["Login"].Length > LoginMaxLength)
            {
                isValid = false;
                message = "Login pode conter no mínimo " + LoginMinLength + " e no máximo " + LoginMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(usuarioDictionary["Senha"]))
            {
                isValid = false;
                message = "Senha é obrigatório.";
            }
            if (usuarioDictionary["Senha"].Length < SenhaMinLength && usuarioDictionary["Senha"].Length > SenhaMaxLength)
            {
                isValid = false;
                message = "Senha pode conter no mínimo " + SenhaMinLength + " e no máximo " + SenhaMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(usuarioDictionary["Nome"]))
            {
                isValid = false;
                message = "Nome é obrigatório.";
            }
            if (usuarioDictionary["Nome"].Length > NomeMaxLength)
            {
                isValid = false;
                message = "Nome pode conter no máximo " + NomeMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(usuarioDictionary["Email"]))
            {
                isValid = false;
                message = "E-mail é obrigatório.";
            }
            if (usuarioDictionary["Email"].Length > EmailMaxLength)
            {
                isValid = false;
                message = "E-mail pode conter no máximo " + EmailMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(usuarioDictionary["Nivel"]))
            {
                isValid = false;
                message = "Nível de acesso é obrigatório.";
            }
            if (!usuarioDictionary.ContainsKey("ClienteId") && !usuarioDictionary.ContainsKey("FuncionarioId"))
            {
                isValid = false;
                message = "Cliente ou funcionário é obrigatório.";
            }
        }

        public static Usuario Parse(Dictionary<string, string> usuarioDictionary)
        {
            Usuario usuario = new Usuario();

            if (!String.IsNullOrEmpty(usuarioDictionary["UsuarioId"]))
                usuario.UsuarioId = Convert.ToInt32(usuarioDictionary["UsuarioId"]);

            if (!String.IsNullOrEmpty(usuarioDictionary["Login"]))
                usuario.Login = usuarioDictionary["Login"];

            if (!String.IsNullOrEmpty(usuarioDictionary["Senha"]))
                usuario.Senha = usuarioDictionary["Senha"];

            if (!String.IsNullOrEmpty(usuarioDictionary["Nome"]))
                usuario.Nome = usuarioDictionary["Nome"];

            if (!String.IsNullOrEmpty(usuarioDictionary["Email"]))
                usuario.Email = usuarioDictionary["Email"];

            if (!String.IsNullOrEmpty(usuarioDictionary["Nivel"]))
                usuario.Nivel = usuarioDictionary["Nivel"];

            if (usuarioDictionary.ContainsKey("ClienteId"))
                if (!String.IsNullOrEmpty(usuarioDictionary["ClienteId"]))
                    usuario.ClienteId = Convert.ToInt32(usuarioDictionary["ClienteId"]);

            if (usuarioDictionary.ContainsKey("FuncionarioId"))
                if (!String.IsNullOrEmpty(usuarioDictionary["FuncionarioId"]))
                    usuario.FuncionarioId = Convert.ToInt32(usuarioDictionary["FuncionarioId"]);

            return usuario;
        }
    }
}
