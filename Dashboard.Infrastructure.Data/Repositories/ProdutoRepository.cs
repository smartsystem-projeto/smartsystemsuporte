using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dashboard.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DashboardContext db)
            :base(db)
        { }

        public Produto ObterPorNome(string nome)
        {
            return _db.Produtos.Single(p => p.Nome == nome);
        }
    }
}
