using Dashboard.Domain.Entities;
using System.Collections.Generic;

namespace Dashboard.Domain.Interfaces.Services
{
    public interface IChamadoService : IServiceBase<Chamado>
    {
        IEnumerable<Chamado> ObterTodosEmAbertoPorClienteId(int clienteId);

        IEnumerable<Chamado> ObterTodosEmAbertoPorFuncionarioId(int funcionarioId);

        void AtualizarFuncionarioIdPorId(int id, int funcionarioId);

        void AtualizarStatusPorId(int id, string status);
    }
}
