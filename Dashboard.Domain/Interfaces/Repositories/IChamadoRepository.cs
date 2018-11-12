using Dashboard.Domain.Entities;
using System.Collections.Generic;

namespace Dashboard.Domain.Interfaces.Repositories
{
    public interface IChamadoRepository : IRepositoryBase<Chamado>
    {
        IEnumerable<Chamado> ObterTodosEmAbertoPorClienteId(int clienteId);

        IEnumerable<Chamado> ObterTodosEmAbertoPorFuncionarioId(int funcionarioId);
    }
}
