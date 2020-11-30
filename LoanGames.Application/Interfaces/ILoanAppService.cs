using FluentValidation.Results;
using LoanGames.Application.InputModels;
using LoanGames.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Application.Interfaces
{
    public interface ILoanAppService
    {
        Task<ValidationResult> Register(LoanInputModel model);
        Task<ValidationResult> GiveBack(LoanInputModel model);

        Task<IEnumerable<LoanViewModel>> GetAll();
    }
}
