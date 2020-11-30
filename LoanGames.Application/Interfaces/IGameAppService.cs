using FluentValidation.Results;
using LoanGames.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Application.Interfaces
{
    public interface IGameAppService
    {
        Task<IEnumerable<GameViewModel>> GetAll();
        Task<GameViewModel> GetById(Guid id);
        Task<GameViewModel> GetByName(string name);

        Task<ValidationResult> Add(GameViewModel model);
        Task<ValidationResult> Update(GameViewModel model);
        Task<ValidationResult> Remove(Guid id);
        Task<ValidationResult> RegistraEmprestimo(Guid id, Guid personId);
        Task<ValidationResult> RegistraDevolucao(Guid id, Guid personId);
    }
}
