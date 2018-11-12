using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Infrastructure.Data.Repositories
{
    public class AssuntoChamadoRepository : RepositoryBase<AssuntoChamado>, IAssuntoChamadoRepository
    {
        public AssuntoChamadoRepository(DashboardContext db)
            :base(db)
        { }

        public override IEnumerable<AssuntoChamado> GetAll()
        {
            return _db.AssuntosChamado
                .Include(assuntoChamado => assuntoChamado.TipoChamado)
                .ToList();
        }

        public override AssuntoChamado GetById(int id)
        {
            return _db.AssuntosChamado
                .Include(assuntoChamado => assuntoChamado.TipoChamado)
                .Single(assuntoChamado => assuntoChamado.AssuntoChamadoId == id);
        }
    }
}
