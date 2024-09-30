using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.DTOs;

namespace CoinkRestAPI.CORE.Interfaces
{
     /// <summary>
    /// Interfaz que define los métodos del servicio de usuarios.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="user">Datos del usuario a crear.</param>
        /// <returns>El usuario creado.</returns>
        Task<User> CreateUserAsync(UserPost user);
    }

    /// <summary>
    /// Interfaz que define los métodos del repositorio de usuarios.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Crea un nuevo usuario en el almacenamiento de datos.
        /// </summary>
        /// <param name="user">Datos del usuario a crear.</param>
        /// <returns>El usuario creado.</returns>
        Task<User> CreateUserAsync(UserPost user);
    }

}