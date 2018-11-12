using Dashboard.Application.Interfaces;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Application.AppServices
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
            :base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Usuario ObterPorNome(string nome)
        {
            return _usuarioService.ObterPorNome(nome);
        }
    }
}
