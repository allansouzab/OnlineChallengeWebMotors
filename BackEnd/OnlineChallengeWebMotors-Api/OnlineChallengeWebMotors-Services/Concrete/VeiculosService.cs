using OnlineChallengeWebMotors.Domain.Entities;
using OnlineChallengeWebMotors.Repository.Interface;
using OnlineChallengeWebMotors_Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineChallengeWebMotors_Services.Concrete
{
    public class VeiculosService : IVeiculosService
    {
        private readonly IVeiculosRepository veiculosRepository;

        public VeiculosService(IVeiculosRepository _veiculosRepository)
        {
            veiculosRepository = _veiculosRepository;
        }

        public Retorno AdicionarCarro(Carro carro)
        {
            return veiculosRepository.Add(carro);
        }

        public Retorno AlterarCarro(Carro carro)
        {
            return veiculosRepository.Alterar(carro);
        }

        public List<Carro> ObterCarros()
        {
            return veiculosRepository.Obter();
        }

        public Retorno RemoverCarro(int id)
        {
            return veiculosRepository.Remover(id);
        }
    }
}
