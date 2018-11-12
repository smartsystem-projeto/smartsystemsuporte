using System.Collections.Generic;
using System.Linq;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.Data.Repositories
{
    public class ChamadoRepository : RepositoryBase<Chamado>, IChamadoRepository
    {
        public ChamadoRepository(DashboardContext db)
            :base(db)
        { }

        public override Chamado GetById(int id)
        {
            return _db.Chamados
                .Include(chamado => chamado.Produto)
                .Include(chamado => chamado.TipoChamado)
                .Include(chamado => chamado.AssuntoChamado)
                .Include(chamado => chamado.PosicionamentosChamado)
                .Include(chamado => chamado.Cliente)
                .Include(chamado => chamado.Funcionario)
                .SingleAsync(chamado => chamado.ChamadoId == id).Result;
        }

        public override IEnumerable<Chamado> GetAll()
        {
            return _db.Chamados
                .Where(chamado => chamado.Status != "Encerrado")
                .Include(chamado => chamado.TipoChamado)
                .Include(chamado => chamado.AssuntoChamado)
                .OrderBy(chamado => chamado.TipoChamado.Prioridade)
                .ToList();
        }

        public IEnumerable<Chamado> ObterTodosEmAbertoPorClienteId(int clienteId)
        {
            return _db.Chamados
                .Where(chamado => chamado.ClienteId == clienteId)
                .Where(chamado => chamado.Status != "Encerrado")
                .Include(chamado => chamado.TipoChamado)
                .Include(chamado => chamado.AssuntoChamado)
                .ToList();
        }

        public IEnumerable<Chamado> ObterTodosEmAbertoPorFuncionarioId(int funcionarioId)
        {
            return _db.Chamados
                .Where(chamado => chamado.FuncionarioId == funcionarioId)
                .Where(chamado => chamado.Status != "Encerrado")
                .Include(chamado => chamado.TipoChamado)
                .Include(chamado => chamado.AssuntoChamado)
                .ToList();
        }
    }
}
