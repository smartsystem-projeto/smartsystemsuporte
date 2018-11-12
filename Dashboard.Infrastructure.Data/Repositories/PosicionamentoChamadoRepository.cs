using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Infrastructure.Data.Context;

namespace Dashboard.Infrastructure.Data.Repositories
{
    public class PosicionamentoChamadoRepository : RepositoryBase<PosicionamentoChamado>, IPosicionamentoChamadoRepository
    {
        public PosicionamentoChamadoRepository(DashboardContext db)
            :base(db)
        { }
    }
}
