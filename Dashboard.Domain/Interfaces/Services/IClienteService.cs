using Dashboard.Domain.Entities;
using System.Collections.Generic;

namespace Dashboard.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        Cliente Valid(Dictionary<string, string> clienteDictionary);
    }
}
