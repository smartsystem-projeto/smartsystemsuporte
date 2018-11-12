using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dashboard.Infrastructure.Data.Repositories
{
    public class TipoChamadoRepository : RepositoryBase<TipoChamado>, ITipoChamadoRepository
    {
        public TipoChamadoRepository(DashboardContext db)
            :base(db)
        { }
    }
}
