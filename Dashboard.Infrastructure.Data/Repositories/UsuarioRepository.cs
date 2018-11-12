using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dashboard.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DashboardContext db)
            :base(db)
        { }

        public Usuario ObterPorLogin(string login)
        {
            try
            {
                return _db.Usuarios.Single(u => u.Login == login);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public Usuario ObterPorFuncionarioId(int funcionarioId)
        {
            try
            {
                return _db.Usuarios
                    .Single(usuario => usuario.FuncionarioId == funcionarioId);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
