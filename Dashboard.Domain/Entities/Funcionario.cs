using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Entities
{
    public class Funcionario : absValidationBase
    {
        public int FuncionarioId { get; set; }

        public bool Status { get; set; }

        public string NomeTratamento { get; set; }
        public const int NomeTratamentoMaxLength = 30;

        public Endereco Endereco { get; set; }

        public string CPF { get; set; }
        public const int CPFMaxLength = 11;

        public List<Telefone> Telefones { get; set; }

        public Usuario Usuario { get; set; }

        public List<Chamado> Chamados { get; set; }

        public List<PosicionamentoChamado> PosicionamentosChamado { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public void Valid(Dictionary<string, string> funcionarioDictionary)
        {
            isValid = true;

            if (funcionarioDictionary["NomeTratamento"].Length > NomeTratamentoMaxLength)
            {
                isValid = false;
                message = "Nome de tratamento pode conter no máximo " + NomeTratamentoMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(funcionarioDictionary["CPF"]))
            {
                isValid = false;
                message = "CPF é obrigatório.";
            }
            if (!IsNumeric(funcionarioDictionary["CPF"]))
            {
                isValid = false;
                message = "CPF só pode conter números.";
            }
            if (funcionarioDictionary["CPF"].Length > CPFMaxLength)
            {
                isValid = false;
                message = "CPF pode conter no máximo " + CPFMaxLength + " caracteres.";
            }
        }

        public static Funcionario Parse(Dictionary<string, string> funcionarioDictionary)
        {
            Funcionario funcionario = new Funcionario();

            if (!String.IsNullOrEmpty(funcionarioDictionary["FuncionarioId"]))
                funcionario.FuncionarioId = Convert.ToInt32(funcionarioDictionary["FuncionarioId"]);

            if (!String.IsNullOrEmpty(funcionarioDictionary["NomeTratamento"]))
                funcionario.NomeTratamento = funcionarioDictionary["NomeTratamento"];

            if (!String.IsNullOrEmpty(funcionarioDictionary["CPF"]))
                funcionario.CPF = funcionarioDictionary["CPF"];

            return funcionario;
        }
    }
}
