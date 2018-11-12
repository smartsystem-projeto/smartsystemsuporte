using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Infrastructure.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(DashboardContext db)
            :base(db)
        { }

        public override IEnumerable<Cliente> GetAll()
        {
            return _db.Clientes
                .Include(cliente => cliente.Endereco)
                .Include(cliente => cliente.Telefones)
                .ToListAsync().Result;
        }

        public override Cliente GetById(int id)
        {
            return _db.Clientes
                .Include(cliente => cliente.Endereco)
                .Include(cliente => cliente.Telefones)
                .SingleAsync(cliente => cliente.ClienteId == id).Result;
        }

        public override bool Update(Cliente cliente)
        {
            try
            {
                if (cliente.Telefones.Count > 0)
                {
                    foreach (var telefone in cliente.Telefones)
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
                        .Where(telefone => telefone.ClienteId == cliente.ClienteId)
                        .ToList();

                if (telefones.Count > 0)
                {
                    foreach (var telefone in telefones)
                    {
                        if (!cliente.Telefones.Contains(telefone))
                        {
                            _db.Remove(telefone);
                        }
                    }
                }

                _db.Entry(cliente).State = EntityState.Modified;

                if (cliente.Endereco.EnderecoId != 0)
                {
                    _db.Entry(cliente.Endereco).State = EntityState.Modified;
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
