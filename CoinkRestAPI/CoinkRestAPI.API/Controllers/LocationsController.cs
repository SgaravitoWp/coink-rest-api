using CoinkRestAPI.CORE.DTOs;
using Microsoft.AspNetCore.Mvc;
using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.Interfaces;

namespace CoinRestAPI.API.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones relacionadas con ubicaciones geográficas.
    /// </summary>
    [ApiController]
    [Route("")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        /// <summary>
        /// Constructor del controlador de ubicaciones.
        /// </summary>
        /// <param name="locationService">Servicio de ubicaciones inyectado.</param>
        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Obtiene la lista de países.
        /// </summary>
        /// <returns>Una lista de países.</returns>
        [HttpGet]
        [Route("listCountries")]
        [ProducesResponseType(typeof(SuccessResponse<Country>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListCountries()
        {
            var countries = await _locationService.GetCountriesAsync();
            return Ok(new SuccessResponse<Country>
            {
                success = true,
                message = "Countries",
                data = countries,
                status_code = 200
            });
        }

        /// <summary>
        /// Obtiene la lista de estados para un país específico.
        /// </summary>
        /// <param name="state">DTO con el ID del país.</param>
        /// <returns>Una lista de estados del país especificado.</returns>
        [HttpGet]
        [Route("listStates")]
        [ProducesResponseType(typeof(SuccessResponse<State>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListStates([FromQuery] StateGet state)
        {
            var states = await _locationService.GetStatesByCountryAsync(state.country_id);
            string message = states.Any() ? "States" : "No states were found for the data provided.";
            return Ok(new SuccessResponse<State>
            {
                success = true,
                message = message,
                data = states,
                status_code = 200
            });
        }

        /// <summary>
        /// Obtiene la lista de ciudades para un estado específico.
        /// </summary>
        /// <param name="city">DTO con el ID del estado.</param>
        /// <returns>Una lista de ciudades del estado especificado.</returns>
        [HttpGet]
        [Route("listCities")]
        [ProducesResponseType(typeof(SuccessResponse<City>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListCities([FromQuery] CityGet city)
        {
            var cities = await _locationService.GetCitiesByStateAsync(city.state_id);
            string message = cities.Any() ? "Cities" : "No cities were found for the data provided.";
            return Ok(new SuccessResponse<City>
            {
                success = true,
                message = message,
                data = cities,
                status_code = 200
            });
        }
    }
}