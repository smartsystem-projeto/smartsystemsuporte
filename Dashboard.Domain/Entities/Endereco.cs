using System;
using System.Collections.Generic;

namespace Dashboard.Domain.Entities
{
    public class Endereco : absValidationBase
    {
        public int EnderecoId { get; set; }

        public string Rua { get; set; }
        public const int RuaMaxLength = 100;

        public int Numero { get; set; }

        public string Bairro { get; set; }
        public const int BairroMaxLength = 40;

        public string Cidade { get; set; }
        public const int CidadeMaxLength = 20;

        public string UF { get; set; }
        public const int UFMaxLength = 2;

        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public void Valid(Dictionary<string, string> enderecoDictionary)
        {
            isValid = true;

            if (String.IsNullOrEmpty(enderecoDictionary["Rua"]))
            {
                isValid = false;
                message = "Rua é obrigatório.";
            }
            if (enderecoDictionary["Rua"].Length > RuaMaxLength)
            {
                isValid = false;
                message = "Rua pode conter no máximo " + RuaMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(enderecoDictionary["Numero"]))
            {
                isValid = false;
                message = "Número é obrigatório.";
            }
            if (!IsNumeric(enderecoDictionary["Numero"]))
            {
                isValid = false;
                message = "Número só pode conter números.";
            }
            if (String.IsNullOrEmpty(enderecoDictionary["Bairro"]))
            {
                isValid = false;
                message = "Bairro é obrigatório.";
            }
            if (enderecoDictionary["Bairro"].Length > BairroMaxLength)
            {
                isValid = false;
                message = "Bairro pode conter no máximo " + BairroMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(enderecoDictionary["Cidade"]))
            {
                isValid = false;
                message = "Cidade é obrigatório.";
            }
            if (enderecoDictionary["Cidade"].Length > CidadeMaxLength)
            {
                isValid = false;
                message = "Cidade pode conter no máximo " + CidadeMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(enderecoDictionary["UF"]))
            {
                isValid = false;
                message = "UF é obrigatório.";
            }
            if (enderecoDictionary["UF"].Length > UFMaxLength)
            {
                isValid = false;
                message = "UF pode conter no máximo " + UFMaxLength + " caracteres.";
            }
        }

        public static Endereco Parse(Dictionary<string, string> enderecoDictionary)
        {
            Endereco endereco = new Endereco();

                if (!String.IsNullOrEmpty(enderecoDictionary["EnderecoId"]))
                    endereco.EnderecoId = Convert.ToInt32(enderecoDictionary["EnderecoId"]);

            if (!String.IsNullOrEmpty(enderecoDictionary["Rua"]))
                endereco.Rua = enderecoDictionary["Rua"];

            if (!String.IsNullOrEmpty(enderecoDictionary["Numero"]))
                endereco.Numero = Convert.ToInt32(enderecoDictionary["Numero"]);

            if (!String.IsNullOrEmpty(enderecoDictionary["Bairro"]))
                endereco.Bairro = enderecoDictionary["Bairro"];

            if (!String.IsNullOrEmpty(enderecoDictionary["Cidade"]))
                endereco.Cidade = enderecoDictionary["Cidade"];

            if (!String.IsNullOrEmpty(enderecoDictionary["UF"]))
                endereco.UF = enderecoDictionary["UF"];

            return endereco;
        }
    }
}
