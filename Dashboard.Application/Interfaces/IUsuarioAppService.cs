using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Usuario ObterPorNome(String nome);
    }
}
