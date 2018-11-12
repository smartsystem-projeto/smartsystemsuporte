using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Dashboard.Domain.Services
{
    public class TipoChamadoService : ServiceBase<TipoChamado>, ITipoChamadoService
    {
        private readonly ITipoChamadoRepository _tipoChamadoRepository;

        public TipoChamadoService(ITipoChamadoRepository tipoChamadoRepository)
            :base(tipoChamadoRepository)
        {
            _tipoChamadoRepository = tipoChamadoRepository;
        }

        public TipoChamado Valid(Dictionary<string, string> tipoChamadoDictionary)
        {
            TipoChamado tipoChamado = new TipoChamado();
            tipoChamado.Valid(tipoChamadoDictionary);

            if (!tipoChamado.IsValid())
            {
                message = tipoChamado.GetMessage();
                return null;
            }

            tipoChamado = TipoChamado.Parse(tipoChamadoDictionary);
            return tipoChamado;
        }
    }
}
