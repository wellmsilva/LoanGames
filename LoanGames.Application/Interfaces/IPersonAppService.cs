using FluentValidation.Results;
using LoanGames.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanGames.Application.Interfaces
{
   public interface IPersonAppService : IDisposable
    {
        Task<IEnumerable<PersonViewModel>> GetAll();
        Task<PersonViewModel> GetById(Guid id);
        Task<PersonViewModel> GetByName(string name);

        Task<ValidationResult> Add(PersonViewModel model);
        Task<ValidationResult> Update(PersonViewModel model);
        Task<ValidationResult> Remove(Guid id);
    }
}
