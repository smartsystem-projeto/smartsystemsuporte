using Dashboard.Domain.Entities;
using System.Collections.Generic;

namespace Dashboard.Domain.Interfaces.Services
{
    public interface IPosicionamentoChamadoService : IServiceBase<PosicionamentoChamado>
    {
        PosicionamentoChamado Valid(Dictionary<string, string> posicionamentoChamadoDictionary);
    }
}
