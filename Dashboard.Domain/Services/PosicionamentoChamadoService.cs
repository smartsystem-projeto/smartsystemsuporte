using System;
using System.Collections.Generic;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Repositories;
using Dashboard.Domain.Interfaces.Services;

namespace Dashboard.Domain.Services
{
    public class PosicionamentoChamadoService : ServiceBase<PosicionamentoChamado>, IPosicionamentoChamadoService
    {
        private readonly IPosicionamentoChamadoRepository _posicionamentoChamadoRepository;
        private readonly IChamadoService _chamadoService;

        public PosicionamentoChamadoService(
            IPosicionamentoChamadoRepository posicionamentoChamadoRepository,
            IChamadoService chamadoService
            )
            :base(posicionamentoChamadoRepository)
        {
            _posicionamentoChamadoRepository = posicionamentoChamadoRepository;
            _chamadoService = chamadoService;
        }

        public override PosicionamentoChamado Add(PosicionamentoChamado posicionamentoChamado)
        {
            var chamado = _chamadoService.GetById(posicionamentoChamado.ChamadoId);

            if (posicionamentoChamado.ClienteId != null)
            {
                chamado.Responsavel = "Técnico";
            }
            else if (posicionamentoChamado.FuncionarioId != null)
            {
                chamado.Responsavel = "Cliente";
            }

            chamado.UltimoPosicionamento = DateTime.Now;

            return _posicionamentoChamadoRepository.Add(posicionamentoChamado);
        }

        public PosicionamentoChamado Valid(Dictionary<string, string> posicionamentoChamadoDictionary)
        {
            PosicionamentoChamado posicionamentoChamado = new PosicionamentoChamado();
            posicionamentoChamado.Valid(posicionamentoChamadoDictionary);

            if (!posicionamentoChamado.IsValid())
            {
                message = posicionamentoChamado.GetMessage();
                return null;
            }

            posicionamentoChamado = PosicionamentoChamado.Parse(posicionamentoChamadoDictionary);
            return posicionamentoChamado;
        }
    }
}
