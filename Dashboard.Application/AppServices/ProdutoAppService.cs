using Dashboard.Application.Interfaces;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Application.AppServices
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
            :base(produtoService)
        {
            _produtoService = produtoService;
        }

        public Produto ObterPorNome(string nome)
        {
            return _produtoService.ObterPorNome(nome);
        }
    }
}
