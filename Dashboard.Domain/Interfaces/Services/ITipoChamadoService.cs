using Dashboard.Domain.Entities;
using System.Collections.Generic;

namespace Dashboard.Domain.Interfaces.Services
{
    public interface ITipoChamadoService : IServiceBase<TipoChamado>
    {
        TipoChamado Valid(Dictionary<string, string> tipoChamadoDictionary);
    }
}
