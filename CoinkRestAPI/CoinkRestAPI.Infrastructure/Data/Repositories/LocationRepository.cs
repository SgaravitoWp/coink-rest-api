using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.Interfaces;
using Npgsql;

namespace CoinRestAPI.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Repositorio para manejar operaciones relacionadas con ubicaciones.
    /// </summary>
    public class LocationRepository : ConnectionRepository, ILocationRepository
    {
        /// <summary>
        /// Constructor del repositorio de ubicaciones.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        public LocationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Obtiene todos los países de la base de datos.
        /// </summary>
        /// <returns>Una colección de países.</returns>
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new NpgsqlCommand("SELECT * FROM GetCountries()", connection);
            using var reader = await command.ExecuteReaderAsync();
            var countries = new List<Country>();
            while (await reader.ReadAsync())
            {
                countries.Add(new Country
                {
                    id = reader["id"].ToString(),
                    name = reader["name"].ToString(),
                });
            }
            return countries;
        }

        /// <summary>
        /// Obtiene los estados/departamentos de un país específico.
        /// </summary>
        /// <param name="countryId">ID del país.</param>
        /// <returns>Una colección de estados/departamentos del país especificado.</returns>
        public async Task<IEnumerable<State>> GetStatesByCountryAsync(string countryId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new NpgsqlCommand("SELECT * FROM GetStates(@id_country)", connection);
            command.Parameters.AddWithValue("id_country", countryId);
            using var reader = await command.ExecuteReaderAsync();
            var states = new List<State>();
            while (await reader.ReadAsync())
            {
                states.Add(new State
                {
                    id = Convert.ToInt32(reader["id"]),
                    country_id = reader["country_id"].ToString(),
                    name = reader["name"].ToString(),
                });
            }
            return states;
        }

        /// <summary>
        /// Obtiene las ciudades/municipios de un estado/departamento específico.
        /// </summary>
        /// <param name="stateId">ID del estado/departamento.</param>
        /// <returns>Una colección de ciudades/municipios del estado/departamento especificado.</returns>
        public async Task<IEnumerable<City>> GetCitiesByStateAsync(int stateId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new NpgsqlCommand("SELECT * FROM GetCities(@id_state)", connection);
            command.Parameters.AddWithValue("id_state", stateId);
            using var reader = await command.ExecuteReaderAsync();
            var cities = new List<City>();
            while (await reader.ReadAsync())
            {
                cities.Add(new City
                {
                    id = Convert.ToInt32(reader["id"]),
                    state_id = Convert.ToInt32(reader["state_id"]),
                    name = reader["name"].ToString(),
                });
            }
            return cities;
        }
    }
}