using LoanGames.Application.InputModels;
using LoanGames.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<UserViewModel> Authenticate(LoginInputModel model);
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int userId);
    }
}
