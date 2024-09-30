using CoinkRestAPI.CORE.Entities;

namespace CoinkRestAPI.CORE.Interfaces
{
    /// <summary>
    /// Interfaz que define los métodos del servicio de ubicaciones.
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Obtiene todos los países.
        /// </summary>
        /// <returns>Una colección de países.</returns>
        Task<IEnumerable<Country>> GetCountriesAsync();

        /// <summary>
        /// Obtiene los estados/departamentos de un país específico.
        /// </summary>
        /// <param name="country_id">ID del país.</param>
        /// <returns>Una colección de estados/departamentos del país especificado.</returns>
        Task<IEnumerable<State>> GetStatesByCountryAsync(string country_id);

        /// <summary>
        /// Obtiene las ciudades/municipios de un estado/departamento específico.
        /// </summary>
        /// <param name="state_id">ID del estado/departamento.</param>
        /// <returns>Una colección de ciudades/municipios del estado/departamento especificado.</returns>
        Task<IEnumerable<City>> GetCitiesByStateAsync(int state_id);
    }

    /// <summary>
    /// Interfaz que define los métodos del repositorio de ubicaciones.
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Obtiene todos los países desde el almacenamiento de datos.
        /// </summary>
        /// <returns>Una colección de países.</returns>
        Task<IEnumerable<Country>> GetCountriesAsync();

        /// <summary>
        /// Obtiene los estados/departamentos de un país específico desde el almacenamiento de datos.
        /// </summary>
        /// <param name="country_id">ID del país.</param>
        /// <returns>Una colección de estados/departamentos del país especificado.</returns>
        Task<IEnumerable<State>> GetStatesByCountryAsync(string country_id);

        /// <summary>
        /// Obtiene las ciudades/municipios de un estado/departamento específico desde el almacenamiento de datos.
        /// </summary>
        /// <param name="state_id">ID del estado/departamento.</param>
        /// <returns>Una colección de ciudades/municipios del estado/departamento especificado.</returns>
        Task<IEnumerable<City>> GetCitiesByStateAsync(int state_id);
    }

}