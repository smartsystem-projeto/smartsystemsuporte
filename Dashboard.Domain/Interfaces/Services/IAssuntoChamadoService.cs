using Dashboard.Domain.Entities;
using System.Collections.Generic;

namespace Dashboard.Domain.Interfaces.Services
{
    public interface IAssuntoChamadoService : IServiceBase<AssuntoChamado>
    {
        AssuntoChamado Valid(Dictionary<string, string> assuntoChamadoDictionary);
    }
}
