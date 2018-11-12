using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Produto ObterPorNome(string nome);
    }
}
