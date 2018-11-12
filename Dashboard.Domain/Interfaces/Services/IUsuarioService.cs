using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario ObterPorLogin(string login);

        Usuario Valid(Dictionary<string, string> usuarioDictionary);

        Usuario Login(Dictionary<string, string> loginDictionary);
    }
}
