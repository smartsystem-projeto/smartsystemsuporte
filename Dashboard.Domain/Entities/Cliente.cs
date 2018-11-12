using System;
using System.Collections.Generic;

namespace Dashboard.Domain.Entities
{
    public class Cliente : absValidationBase
    {
        public int ClienteId { get; set; }

        public bool Status { get; set; }

        public string RazaoSocial { get; set; }
        public const int RazaoSocialMaxLength = 50;

        public string NomeFantasia { get; set; }
        public const int NomeFantasiaMaxLength = 50;

        public Endereco Endereco { get; set; }

        public string CNPJ { get; set; }
        public const int CNPJMaxLength = 14;

        public string CPF { get; set; }
        public const int CPFMaxLength = 11;

        public List<Telefone> Telefones { get; set; }

        public string Email { get; set; }
        public const int EmailMaxLength = 50;

        public int? TempoResposta { get; set; }

        public List<ClienteProduto> ClienteProdutos { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public List<Chamado> Chamados { get; set; }

        public List<PosicionamentoChamado> PosicionamentosChamado { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public void Valid(Dictionary<string, string> clienteDictionary)
        {
            isValid = true;

            if (String.IsNullOrEmpty(clienteDictionary["RazaoSocial"]))
            {
                isValid = false;
                message = "Razão social é obrigatório.";
            }
            if (clienteDictionary["RazaoSocial"].Length > RazaoSocialMaxLength)
            {
                isValid = false;
                message = "Razão social pode conter no máximo " + RazaoSocialMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(clienteDictionary["NomeFantasia"]))
            {
                isValid = false;
                message = "Nome fantasia é obrigatório.";
            }
            if (clienteDictionary["NomeFantasia"].Length > NomeFantasiaMaxLength)
            {
                isValid = false;
                message = "Nome fantasia pode conter no máximo " + NomeFantasiaMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(clienteDictionary["CNPJ"]) && String.IsNullOrEmpty(clienteDictionary["CPF"]))
            {
                isValid = false;
                message = "CNPJ ou CPF é obrigatório.";
            }
            if (clienteDictionary.ContainsKey("CNPJ"))
            {
                if (!IsNumeric(clienteDictionary["CNPJ"]))
                {
                    isValid = false;
                    message = "CNPJ só pode conter números.";
                }

                if (clienteDictionary["CNPJ"].Length > CNPJMaxLength)
                {
                    isValid = false;
                    message = "CNPJ pode conter no máximo " + CNPJMaxLength + " caracteres.";
                }
            }
            if (clienteDictionary.ContainsKey("CPF"))
            {
                if (!IsNumeric(clienteDictionary["CPF"]))
                {
                    isValid = false;
                    message = "CPF só pode conter números.";
                }

                if (clienteDictionary["CPF"].Length > CPFMaxLength)
                {
                    isValid = false;
                    message = "CPF pode conter no máximo " + CPFMaxLength + " caracteres.";
                }
            }
            if (String.IsNullOrEmpty(clienteDictionary["Email"]))
            {
                isValid = false;
                message = "E-mail é obrigatório.";
            }
            if (clienteDictionary["Email"].Length > EmailMaxLength)
            {
                isValid = false;
                message = "E-mail pode conter no máximo " + EmailMaxLength + " caracteres.";
            }
            if (!IsNumeric(clienteDictionary["TempoResposta"]))
            {
                isValid = false;
                message = "Tempo de resposta só pode conter números.";
            }
        }

        public static Cliente Parse(Dictionary<string, string> clienteDictionary)
        {
            Cliente cliente = new Cliente();

            if (!String.IsNullOrEmpty(clienteDictionary["ClienteId"]))
                cliente.ClienteId = Convert.ToInt32(clienteDictionary["ClienteId"]);

            if (!String.IsNullOrEmpty(clienteDictionary["RazaoSocial"]))
                cliente.RazaoSocial = clienteDictionary["RazaoSocial"];

            if (!String.IsNullOrEmpty(clienteDictionary["NomeFantasia"]))
                cliente.NomeFantasia = clienteDictionary["NomeFantasia"];

            if (!String.IsNullOrEmpty(clienteDictionary["CNPJ"]))
                cliente.CNPJ = clienteDictionary["CNPJ"];

            if (!String.IsNullOrEmpty(clienteDictionary["CPF"]))
                cliente.CPF = clienteDictionary["CPF"];

            if (!String.IsNullOrEmpty(clienteDictionary["Email"]))
                cliente.Email = clienteDictionary["Email"];

            if (!String.IsNullOrEmpty(clienteDictionary["TempoResposta"]))
                cliente.TempoResposta = Convert.ToInt32(clienteDictionary["TempoResposta"]);

            return cliente;
        }
    }
}
