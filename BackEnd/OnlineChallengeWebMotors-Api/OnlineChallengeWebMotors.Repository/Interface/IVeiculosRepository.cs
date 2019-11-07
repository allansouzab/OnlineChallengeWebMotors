using OnlineChallengeWebMotors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineChallengeWebMotors.Repository.Interface
{
    public interface IVeiculosRepository
    {
        Retorno Add(Carro carro);
        Retorno Remover(int id);
        Retorno Alterar(Carro carro);
        List<Carro> Obter();
    }
}
