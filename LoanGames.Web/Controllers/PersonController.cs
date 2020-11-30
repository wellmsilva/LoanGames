using LoanGames.Application.Interfaces;
using LoanGames.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class PersonController : ControllerBase
    {

        private readonly IPersonAppService _personAppService;

        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

       
        [HttpGet()]
        public async Task<IEnumerable<PersonViewModel>> Get()
        {
            return await _personAppService.GetAll();
        } 

        [HttpGet("{id}")]
        public async Task<PersonViewModel> Get(Guid id)
        {
            return await _personAppService.GetById(id);
        }

        [HttpGet("{name}")]
        public async Task<PersonViewModel> Get(string name)
        {
            return await _personAppService.GetByName(name);
        }

        [HttpPost()]
        public async Task Post(PersonViewModel model)
        {
            await _personAppService.Add(model);
        }

        [HttpPut()]
        public async Task Put(PersonViewModel model)
        {
            await _personAppService.Update(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _personAppService.Remove(id);
        }



     


    }
}
