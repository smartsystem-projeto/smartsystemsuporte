using System;
using System.Collections.Generic;

namespace Dashboard.Domain.Entities
{
    public class TipoChamado : absValidationBase
    {
        public int TipoChamadoId { get; set; }

        public string Descricao { get; set; }
        public const int DescricaoMaxLength = 50;

        public int Prioridade { get; set; }

        public List<AssuntoChamado> AssuntosChamado { get; set; }

        public List<Chamado> Chamados { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public void Valid(Dictionary<string, string> tipoChamadoDictionary)
        {
            isValid = true;

            if (String.IsNullOrEmpty(tipoChamadoDictionary["Descricao"]))
            {
                isValid = false;
                message = "Descrição é obrigatório.";
            }
            if (tipoChamadoDictionary["Descricao"].Length > DescricaoMaxLength)
            {
                isValid = false;
                message = "Descrição pode conter no máximo " + DescricaoMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(tipoChamadoDictionary["Prioridade"]))
            {
                isValid = false;
                message = "Prioridade é obrigatório.";
            }
            if (!IsNumeric(tipoChamadoDictionary["Prioridade"]))
            {
                isValid = false;
                message = "Prioridade só pode conter números.";
            }
        }

        public static TipoChamado Parse(Dictionary<string, string> tipoChamadoDictionary)
        {
            TipoChamado tipoChamado = new TipoChamado();

            if (!String.IsNullOrEmpty(tipoChamadoDictionary["TipoChamadoId"]))
                tipoChamado.TipoChamadoId = Convert.ToInt32(tipoChamadoDictionary["TipoChamadoId"]);

            if (!String.IsNullOrEmpty(tipoChamadoDictionary["Descricao"]))
                tipoChamado.Descricao = tipoChamadoDictionary["Descricao"];

            if (!String.IsNullOrEmpty(tipoChamadoDictionary["Prioridade"]))
                tipoChamado.Prioridade = Convert.ToInt32(tipoChamadoDictionary["Prioridade"]);

            return tipoChamado;
        }
    }
}
