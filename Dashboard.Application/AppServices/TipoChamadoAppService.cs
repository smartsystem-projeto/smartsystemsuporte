using Dashboard.Application.Interfaces;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dashboard.Application.AppServices
{
    public class TipoChamadoAppService : AppServiceBase<TipoChamado>, ITipoChamadoAppService
    {
        private readonly ITipoChamadoService _tipoChamadoService;

        public TipoChamadoAppService(ITipoChamadoService tipoChamadoService)
            :base(tipoChamadoService)
        {
            _tipoChamadoService = tipoChamadoService;
        }

        public IEnumerable<TipoChamado> GetAllOrderByPrioridade()
        {
            return _tipoChamadoService.GetAll().OrderBy(t => t.Prioridade);
        }
    }
}
