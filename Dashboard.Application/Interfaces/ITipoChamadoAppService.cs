using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Application.Interfaces
{
    public interface ITipoChamadoAppService : IAppServiceBase<TipoChamado>
    {
        IEnumerable<TipoChamado> GetAllOrderByPrioridade();
    }
}
