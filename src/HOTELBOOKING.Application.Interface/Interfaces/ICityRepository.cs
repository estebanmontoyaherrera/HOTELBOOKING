using HOTELBOOKING.Application.Dtos.City.Response;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface ICityRepository : IGenericRepository<City>
    {
        Task<IEnumerable<GetAllCityResponseDto>> GetAllCities(string storedProcedure);
    }
}
