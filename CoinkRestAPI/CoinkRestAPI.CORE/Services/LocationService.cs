using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.Interfaces;

namespace CoinRestAPI.CORE.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _locationRepository.GetCountriesAsync();
        }

        public async Task<IEnumerable<State>> GetStatesByCountryAsync(string country_id)
        {
            return await _locationRepository.GetStatesByCountryAsync(country_id);
        }

        public async Task<IEnumerable<City>> GetCitiesByStateAsync(int state_id)
        {
            return await _locationRepository.GetCitiesByStateAsync(state_id);
        }
    }
}