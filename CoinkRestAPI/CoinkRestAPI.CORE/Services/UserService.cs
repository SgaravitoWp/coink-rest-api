using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.Interfaces;
using CoinkRestAPI.CORE.DTOs;


namespace CoinkRestAPI.CORE.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(UserPost user)
    {
        // Aquí iría la lógica de negocio, como validaciones
        return await _userRepository.CreateUserAsync(user);
    }

}