using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Application.Interfaces
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        Produto ObterPorNome(String nome);
    }
}
