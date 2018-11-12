using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Dashboard.Domain.Services
{
    public class FuncionarioService : ServiceBase<Funcionario>, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
            :base(funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public Funcionario Valid(Dictionary<string, string> funcionarioDictionary)
        {
            Funcionario funcionario = new Funcionario();
            Endereco endereco = new Endereco();
            Telefone telefone1 = new Telefone();
            Telefone telefone2 = new Telefone();
            Dictionary<string, string> telefoneDictionary1 = new Dictionary<string, string>();
            Dictionary<string, string> telefoneDictionary2 = new Dictionary<string, string>();
            Usuario usuario = new Usuario();

            funcionario.Valid(funcionarioDictionary);

            if (!funcionario.IsValid())
            {
                message = funcionario.GetMessage();
                return null;
            }

            funcionario = Funcionario.Parse(funcionarioDictionary);
            endereco.Valid(funcionarioDictionary);

            if (endereco.IsValid())
            {
                endereco = Endereco.Parse(funcionarioDictionary);
                funcionario.Endereco = endereco;
            }
            else
            {
                message = endereco.GetMessage();
                return null;
            }

            funcionario.Telefones = new List<Telefone>();
            telefoneDictionary1["TelefoneId"] = funcionarioDictionary["Telefone1Id"];
            telefoneDictionary1["DDD"] = funcionarioDictionary["Telefone1DDD"];
            telefoneDictionary1["Numero"] = funcionarioDictionary["Telefone1Numero"];
            telefone1.Valid(telefoneDictionary1);

            if (telefone1.IsValid())
            {
                telefone1 = Telefone.Parse(telefoneDictionary1);
                funcionario.Telefones.Add(telefone1);
            }

            telefoneDictionary2["TelefoneId"] = funcionarioDictionary["Telefone2Id"];
            telefoneDictionary2["DDD"] = funcionarioDictionary["Telefone2DDD"];
            telefoneDictionary2["Numero"] = funcionarioDictionary["Telefone2Numero"];
            telefone2.Valid(telefoneDictionary2);

            if (telefone2.IsValid())
            {
                telefone2 = Telefone.Parse(telefoneDictionary2);
                funcionario.Telefones.Add(telefone2);
            }

            return funcionario;
        }
    }
}
