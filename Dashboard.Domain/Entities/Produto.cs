using System;
using System.Collections.Generic;

namespace Dashboard.Domain.Entities
{
    public class Produto : absValidationBase
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }
        public const int NomeMaxLength = 50;

        public string Descricao { get; set; }
        public const int DescricaoMaxLength = 255;

        public List<ClienteProduto> ClienteProdutos { get; set; }

        public List<Chamado> Chamados { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public void Valid(Dictionary<string, string> produtoDictionary)
        {
            isValid = true;

            if (String.IsNullOrEmpty(produtoDictionary["Nome"]))
            {
                isValid = false;
                message = "Nome é obrigatório.";
            }
            if (produtoDictionary["Nome"].Length > NomeMaxLength)
            {
                isValid = false;
                message = "Nome pode conter no máximo "+NomeMaxLength+" caracteres.";
            }
            if (produtoDictionary["Descricao"].Length > DescricaoMaxLength)
            {
                isValid = false;
                message = "Descrição pode conter no máximo " + DescricaoMaxLength + " caracteres.";
            }
        }

        public static Produto Parse(Dictionary<string, string> produtoDictionary)
        {
            Produto produto = new Produto();

            if (!String.IsNullOrEmpty(produtoDictionary["ProdutoId"]))
                produto.ProdutoId = Convert.ToInt32(produtoDictionary["ProdutoId"]);

            if (!String.IsNullOrEmpty(produtoDictionary["Nome"]))
                produto.Nome = produtoDictionary["Nome"];

            if (!String.IsNullOrEmpty(produtoDictionary["Descricao"]))
                produto.Descricao = produtoDictionary["Descricao"];

            return produto;
        }
    }
}
