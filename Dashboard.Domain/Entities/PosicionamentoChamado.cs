using System;
using System.Collections.Generic;

namespace Dashboard.Domain.Entities
{
    public class PosicionamentoChamado : absValidationBase
    {
        public int PosicionamentoChamadoId { get; set; }

        public string Descricao { get; set; }
        public const int DescricaoMaxLength = 255;

        public int ChamadoId { get; set; }
        public Chamado Chamado { get; set; }

        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public void Valid(Dictionary<string, string> posicionamentoChamadoDictionary)
        {
            isValid = true;

            if (String.IsNullOrEmpty(posicionamentoChamadoDictionary["ChamadoId"]))
            {
                isValid = false;
                message = "Chamado é obrigatório.";
            }
            if (String.IsNullOrEmpty(posicionamentoChamadoDictionary["Descricao"]))
            {
                isValid = false;
                message = "Descrição é obrigatório.";
            }
            if (posicionamentoChamadoDictionary["Descricao"].Length > DescricaoMaxLength)
            {
                isValid = false;
                message = "Descrição pode conter no máximo " + DescricaoMaxLength + " caracteres.";
            }
        }

        public static PosicionamentoChamado Parse(Dictionary<string, string> posicionamentoChamadoDictionary)
        {
            PosicionamentoChamado posicionamentoChamado = new PosicionamentoChamado();

            if (!String.IsNullOrEmpty(posicionamentoChamadoDictionary["ChamadoId"]))
                posicionamentoChamado.ChamadoId = Convert.ToInt32(posicionamentoChamadoDictionary["ChamadoId"]);

            if (!String.IsNullOrEmpty(posicionamentoChamadoDictionary["Descricao"]))
                posicionamentoChamado.Descricao = posicionamentoChamadoDictionary["Descricao"];

            if (!String.IsNullOrEmpty(posicionamentoChamadoDictionary["FuncionarioId"]))
                posicionamentoChamado.FuncionarioId = Convert.ToInt32(posicionamentoChamadoDictionary["FuncionarioId"]);

            return posicionamentoChamado;
        }
    }
}
