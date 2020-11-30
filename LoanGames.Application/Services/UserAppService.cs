using AutoMapper;
using LoanGames.Application.InputModels;
using LoanGames.Application.Interfaces;
using LoanGames.Application.ViewModels;
using LoanGames.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanGames.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserAppService(IMapper mapper,
                                IUserRepository userRepository
            )
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Authenticate(LoginInputModel model)
        {
            return  _mapper.Map<UserViewModel>(await _userRepository.Login(model.Username, model.Password));
        }


        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(await _userRepository.GetAll());
        }

        public async Task<UserViewModel> GetById(int id)
        {
            return _mapper.Map<UserViewModel>(await _userRepository.GetById(id));
        }
    }
}
