using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            :base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public override Usuario Add(Usuario usuario)
        {
            if (usuario.FuncionarioId != null)
                if (_usuarioRepository.ObterPorFuncionarioId(Convert.ToInt32(usuario.FuncionarioId)) != null)
                    return null;

            return _usuarioRepository.Add(usuario);
        }

        public Usuario ObterPorLogin(string login)
        {
            return _usuarioRepository.ObterPorLogin(login);
        }

        public Usuario Valid(Dictionary<string, string> usuarioDictionary)
        {
            Usuario usuario = new Usuario();
            usuario.Valid(usuarioDictionary);

            if (!usuario.IsValid())
            {
                message = usuario.GetMessage();
                return null;
            }

            usuario = Usuario.Parse(usuarioDictionary);
            return usuario;
        }

        public Usuario Login(Dictionary<string, string> loginDictionary)
        {
            status = true;
            Usuario usuario = new Usuario();
            usuario = ObterPorLogin(loginDictionary["Login"]);

            if (usuario == null)
            {
                status = false;
                message = "Login não encontrado";
                return null;
            }

            if (!loginDictionary["Senha"].Equals(usuario.Senha))
            {
                status = false;
                message = "Senha incorreta";
                return null;
            }

            return usuario;
        }
    }
}
