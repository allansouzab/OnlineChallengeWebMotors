using OnlineChallengeWebMotors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineChallengeWebMotors_Services.Interface
{
    public interface IVeiculosService
    {
        Retorno AdicionarCarro(Carro carro);
        Retorno RemoverCarro(int id);
        Retorno AlterarCarro(Carro carro);
        List<Carro> ObterCarros();
    }
}
