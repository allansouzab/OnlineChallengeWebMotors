using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineChallengeWebMotors.Domain.Entities;
using OnlineChallengeWebMotors_Services.Interface;

namespace OnlineChallengeWebMotors.Api.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculosService veiculosService;

        public VeiculosController(IVeiculosService _veiculosService)
        {
            veiculosService = _veiculosService;
        }

        [HttpGet]
        public List<Carro> ObterTodos()
        {
            return veiculosService.ObterCarros();
        }


        [HttpPost]
        public Retorno Adicionar([FromBody] Carro carro)
        {
            return veiculosService.AdicionarCarro(carro);
        }

        [HttpDelete("{id}")]
        public Retorno Remover(int id)
        {
            return veiculosService.RemoverCarro(id);
        }

        [HttpPatch]
        public Retorno Alterar([FromBody] Carro carro)
        {
            return veiculosService.AlterarCarro(carro);
        }

    }
}