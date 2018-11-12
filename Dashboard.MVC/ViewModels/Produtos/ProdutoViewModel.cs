using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.MVC.ViewModels.Produtos
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(Produto.NomeMaxLength, ErrorMessage = "Nome pode conter no máximo {0} caracteres")]
        public String Nome { get; set; }

        [MaxLength(Produto.DescricaoMaxLength, ErrorMessage = "Descricao pode conter no máximo {0} caracteres")]
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        [Display(Name = "Adicionado")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Última atualização")]
        public DateTime? DataAtualizacao { get; set; }

        public IEnumerable<ProdutoViewModel> ProdutosViewModel { get; set; }

        public String FormAction { get; set; }
    }
}
