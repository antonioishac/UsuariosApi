using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{

    public class UserRegisterService
    {

        private IMapper _mapper;
        private UserManager<User> _userManager;

        public UserRegisterService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task UserRegister(CreateUserDto dto)
        {
            User user = _mapper.Map<User>(dto);

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar o usuário!");
            }
        }
    }
    
}