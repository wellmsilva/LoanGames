using LoanGames.Application.Interfaces;
using LoanGames.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace LoanGames.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {

        private readonly IGameAppService _gameAppService;

        public GameController(IGameAppService gameAppService)
        {
            _gameAppService = gameAppService;
        }

       
        [HttpGet()]
       
        public async Task<IEnumerable<GameViewModel>> Get()
        {
            return await _gameAppService.GetAll();
        } 

        [HttpGet("{id}")]
        public async Task<GameViewModel> Get(Guid id)
        {
            return await _gameAppService.GetById(id);
        }

        [HttpGet("{name}")]
        public async Task<GameViewModel> Get([FromQuery]string name)
        {
            return await _gameAppService.GetByName(name);
        }

        [HttpPost()]
        public async Task Post(GameViewModel model)
        {
            await _gameAppService.Add(model);
        }

        [HttpPut()]
        public async Task Put(GameViewModel model)
        {
            await _gameAppService.Update(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _gameAppService.Remove(id);
        }


        [HttpPost("{id}/emprestimo")]
        public async Task RegistraEmprestimo(Guid id, Guid personId)

        {
             await _gameAppService.RegistraEmprestimo(id, personId);
        }

        [HttpPost("{id}/devolucao")]
        public async Task RegistraDevolucao(Guid id, Guid personId)

        {
            await _gameAppService.RegistraDevolucao(id, personId);
        }
    }
}
