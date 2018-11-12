using Dashboard.Domain.Entities;
using System.Collections.Generic;

namespace Dashboard.Domain.Interfaces.Services
{
    public interface IFuncionarioService : IServiceBase<Funcionario>
    {
        Funcionario Valid(Dictionary<string, string> funcionarioDictionary);
    }
}
