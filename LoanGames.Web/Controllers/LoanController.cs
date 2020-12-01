using FluentValidation.Results;
using LoanGames.Application.InputModels;
using LoanGames.Application.Interfaces;
using LoanGames.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanGames.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoanController : ControllerBase
    {

        private readonly ILoanAppService _appService;

        public LoanController(ILoanAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Registra o empréstimo de um livro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("empresta")]
        public async Task Register(LoanInputModel model)
        {
            await _appService.Register(model);
        }

        /// <summary>
        /// Registra a devolução de um livro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("devolve")]
        public async Task GiveBack(LoanInputModel model)
        {
            await _appService.GiveBack(model);
        }


        [HttpGet]
        public async Task<IEnumerable<LoanViewModel>> GetAll()
        {
            return await _appService.GetAll();
        }
    }
}
