using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.Interfaces;
using CoinkRestAPI.CORE.DTOs;
using Npgsql;

namespace CoinRestAPI.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Repositorio para manejar operaciones relacionadas con usuarios.
    /// </summary>
    public class UserRepository : ConnectionRepository, IUserRepository
    {
        /// <summary>
        /// Constructor del repositorio de usuarios.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Crea un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="user">Datos del usuario a crear.</param>
        /// <returns>El usuario creado.</returns>
        public async Task<User> CreateUserAsync(UserPost user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("SELECT * FROM InsertUser(@id_user, @name, @phone, @address, @id_country, @id_state, @id_city)", connection))
                {
                    command.Parameters.AddWithValue("id_user", user.user_id);
                    command.Parameters.AddWithValue("name", user.name);
                    command.Parameters.AddWithValue("phone", user.phone);
                    command.Parameters.AddWithValue("address", user.address);
                    command.Parameters.AddWithValue("id_country", user.country_id);
                    command.Parameters.AddWithValue("id_state", user.state_id);
                    command.Parameters.AddWithValue("id_city", user.city_id);
                    
                    var user_id = (string)await command.ExecuteScalarAsync();

                    return new User
                    {
                        id = user_id,
                        user_id = user.user_id,
                        name = user.name,
                        phone = user.phone,
                        address = user.address,
                        country_id = user.country_id,
                        state_id = user.state_id,
                        city_id = user.city_id,
                    };
                }
            }
        }
    }
}