using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Infrastructure.Data.Repositories
{
    public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(DashboardContext db)
            :base(db)
        { }

        public override IEnumerable<Funcionario> GetAll()
        {
            return _db.Funcionarios
                .Include(funcionario => funcionario.Endereco)
                .Include(funcionario => funcionario.Telefones)
                .Include(funcionario => funcionario.Usuario)
                .ToListAsync().Result;
        }

        public override Funcionario GetById(int id)
        {
            return _db.Funcionarios
                .Include(funcionario => funcionario.Endereco)
                .Include(funcionario => funcionario.Telefones)
                //.Include(funcionario => funcionario.Usuario)
                .SingleAsync(funcionario => funcionario.FuncionarioId == id).Result;
        }

        public override bool Update(Funcionario funcionario)
        {
            try
            {
                if (funcionario.Telefones.Count > 0)
                {
                    foreach (var telefone in funcionario.Telefones)
                    {
                        if (telefone.TelefoneId != 0)
                        {
                            _db.Entry(telefone).State = EntityState.Modified;
                        }
                        else
                        {
                            _db.Telefones.Add(telefone);
                        }
                    }
                }

                var telefones = _db.Telefones
                        .Where(telefone => telefone.FuncionarioId == funcionario.FuncionarioId)
                        .ToList();

                if (telefones.Count > 0)
                {
                    foreach (var telefone in telefones)
                    {
                        if (!funcionario.Telefones.Contains(telefone))
                        {
                            _db.Remove(telefone);
                        }
                    }
                }

                _db.Entry(funcionario).State = EntityState.Modified;

                if (funcionario.Endereco.EnderecoId != 0)
                {
                    _db.Entry(funcionario.Endereco).State = EntityState.Modified;
                }

                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
