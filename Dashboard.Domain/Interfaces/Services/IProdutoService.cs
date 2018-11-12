using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        Produto Valid(Dictionary<string, string> produtoDictionary);
        Produto ObterPorNome(string nome);
    }
}
