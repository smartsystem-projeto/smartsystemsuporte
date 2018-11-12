using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario ObterPorLogin(string login);

        Usuario ObterPorFuncionarioId(int funcionarioId);
    }
}
