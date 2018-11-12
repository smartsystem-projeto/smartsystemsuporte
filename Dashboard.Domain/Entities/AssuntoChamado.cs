using System;
using System.Collections.Generic;

namespace Dashboard.Domain.Entities
{
    public class AssuntoChamado : absValidationBase
    {
        public int AssuntoChamadoId { get; set; }

        public string Descricao { get; set; }
        public const int DescricaoMaxLength = 50;

        public int TipoChamadoId { get; set; }
        public TipoChamado TipoChamado { get; set; }

        public List<Chamado> Chamados { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public void Valid(Dictionary<string, string> assuntoChamadoDictionary)
        {
            isValid = true;

            if (String.IsNullOrEmpty(assuntoChamadoDictionary["Descricao"]))
            {
                isValid = false;
                message = "Descrição é obrigatório.";
            }
            if (assuntoChamadoDictionary["Descricao"].Length > DescricaoMaxLength)
            {
                isValid = false;
                message = "Descrição pode conter no máximo " + DescricaoMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(assuntoChamadoDictionary["TipoChamadoId"]))
            {
                isValid = false;
                message = "Tipo de chamado é obrigatório.";
            }
        }

        public static AssuntoChamado Parse(Dictionary<string, string> assuntoChamadoDictionary)
        {
            AssuntoChamado assuntoChamado = new AssuntoChamado();

            if (!String.IsNullOrEmpty(assuntoChamadoDictionary["AssuntoChamadoId"]))
                assuntoChamado.AssuntoChamadoId = Convert.ToInt32(assuntoChamadoDictionary["AssuntoChamadoId"]);

            if (!String.IsNullOrEmpty(assuntoChamadoDictionary["Descricao"]))
                assuntoChamado.Descricao = assuntoChamadoDictionary["Descricao"];

            if (!String.IsNullOrEmpty(assuntoChamadoDictionary["TipoChamadoId"]))
                assuntoChamado.TipoChamadoId = Convert.ToInt32(assuntoChamadoDictionary["TipoChamadoId"]);

            return assuntoChamado;
        }
    }
}
