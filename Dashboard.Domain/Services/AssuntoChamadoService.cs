using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Dashboard.Domain.Services
{
    public class AssuntoChamadoService : ServiceBase<AssuntoChamado>, IAssuntoChamadoService
    {
        private readonly IAssuntoChamadoRepository _assuntoChamadoRepository;

        public AssuntoChamadoService(IAssuntoChamadoRepository assuntoChamadoRepository)
            :base(assuntoChamadoRepository)
        {
            _assuntoChamadoRepository = assuntoChamadoRepository;
        }

        public AssuntoChamado Valid(Dictionary<string, string> assuntoChamadoDictionary)
        {
            AssuntoChamado assuntoChamado = new AssuntoChamado();
            assuntoChamado.Valid(assuntoChamadoDictionary);

            if (!assuntoChamado.IsValid())
            {
                message = assuntoChamado.GetMessage();
                return null;
            }

            assuntoChamado = AssuntoChamado.Parse(assuntoChamadoDictionary);
            return assuntoChamado;
        }
    }
}
