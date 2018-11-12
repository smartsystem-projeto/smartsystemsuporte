using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Dashboard.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            :base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Valid(Dictionary<string, string> clienteDictionary)
        {
            Cliente cliente = new Cliente();
            Endereco endereco = new Endereco();
            Telefone telefone1 = new Telefone();
            Telefone telefone2 = new Telefone();
            Dictionary<string, string> telefoneDictionary1 = new Dictionary<string, string>();
            Dictionary<string, string> telefoneDictionary2 = new Dictionary<string, string>();

            cliente.Valid(clienteDictionary);

            if (!cliente.IsValid())
            {
                message = cliente.GetMessage();
                return null;
            }

            cliente = Cliente.Parse(clienteDictionary);
            endereco.Valid(clienteDictionary);

            if (endereco.IsValid())
            {
                endereco = Endereco.Parse(clienteDictionary);
                cliente.Endereco = endereco;
            }
            else
            {
                message = endereco.GetMessage();
                return null;
            }

            cliente.Telefones = new List<Telefone>();
            telefoneDictionary1["TelefoneId"] = clienteDictionary["Telefone1Id"];
            telefoneDictionary1["DDD"] = clienteDictionary["Telefone1DDD"];
            telefoneDictionary1["Numero"] = clienteDictionary["Telefone1Numero"];
            telefone1.Valid(telefoneDictionary1);

            if (telefone1.IsValid())
            {
                telefone1 = Telefone.Parse(telefoneDictionary1);
                telefone1.ClienteId = cliente.ClienteId;
                cliente.Telefones.Add(telefone1);
            }

            telefoneDictionary2["TelefoneId"] = clienteDictionary["Telefone2Id"];
            telefoneDictionary2["DDD"] = clienteDictionary["Telefone2DDD"];
            telefoneDictionary2["Numero"] = clienteDictionary["Telefone2Numero"];
            telefone2.Valid(telefoneDictionary2);

            if (telefone2.IsValid())
            {
                telefone2 = Telefone.Parse(telefoneDictionary2);
                telefone2.ClienteId = cliente.ClienteId;
                cliente.Telefones.Add(telefone2);
            }

            return cliente;
        }
    }
}
