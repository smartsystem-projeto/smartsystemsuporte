using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Dashboard.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            :base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto Valid(Dictionary<string, string> produtoDictionary)
        {
            Produto produto = new Produto();
            produto.Valid(produtoDictionary);

            if (!produto.IsValid())
            {
                message = produto.GetMessage();
                return null;
            }

            produto = Produto.Parse(produtoDictionary);
            return produto;
        }

        public Produto ObterPorNome(string nome)
        {
            return _produtoRepository.ObterPorNome(nome);
        }
    }
}
