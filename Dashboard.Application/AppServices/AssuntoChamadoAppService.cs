using Dashboard.Application.Interfaces;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;

namespace Dashboard.Application.AppServices
{
    public class AssuntoChamadoAppService : AppServiceBase<AssuntoChamado>, IAssuntoChamadoAppService
    {
        private readonly IAssuntoChamadoService _assuntoChamadoService;

        public AssuntoChamadoAppService(IAssuntoChamadoService assuntoChamadoService)
            :base(assuntoChamadoService)
        {
            _assuntoChamadoService = assuntoChamadoService;
        }
    }
}
