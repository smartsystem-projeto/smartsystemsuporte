using System.Collections.Generic;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Domain.Interfaces.Services;

namespace Dashboard.Domain.Services
{
    public class ChamadoService : ServiceBase<Chamado>, IChamadoService
    {
        private readonly IChamadoRepository _chamadoRepository;

        public ChamadoService(IChamadoRepository chamadoRepository)
            :base(chamadoRepository)
        {
            _chamadoRepository = chamadoRepository;
        }

        public IEnumerable<Chamado> ObterTodosEmAbertoPorClienteId(int clienteId)
        {
            return _chamadoRepository.ObterTodosEmAbertoPorClienteId(clienteId);
        }

        public IEnumerable<Chamado> ObterTodosEmAbertoPorFuncionarioId(int funcionarioId)
        {
            return _chamadoRepository.ObterTodosEmAbertoPorFuncionarioId(funcionarioId);
        }

        public void AtualizarFuncionarioIdPorId(int id, int funcionarioId)
        {
            Chamado chamado = GetById(id);
            chamado.FuncionarioId = funcionarioId;
            bool update = Update(chamado);

            if (!update)
            {
                this.status = false;
                message = "Não foi possível atualizar o funcionário responsável";
                return;
            }

            this.status = true;
            message = "Funcionário responsável atualizado com sucesso";
        }

        public void AtualizarStatusPorId(int id, string status)
        {
            Chamado chamado = GetById(id);
            chamado.Status = status;
            bool update = Update(chamado);

            if (!update)
            {
                this.status = false;
                message = "Não foi possível atualizar o status";
                return;
            }

            this.status = true;
            message = "Status atualizado com sucesso";
        }
    }
}
