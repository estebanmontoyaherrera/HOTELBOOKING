using HOTELBOOKING.Application.Dtos.City.Response;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface ICityRepository : IGenericRepository<City>
    {
        Task<IEnumerable<GetAllCityResponseDto>> GetAllCities(string storedProcedure);
        
        //Task<IEnumerable<Hotel>> GetHotelsByCityId(int cityId);
        //Task<IEnumerable<Room>> GetAvailableRoomsByHotelAsync(int hotelId, DateTime checkInDate, DateTime checkOutDate, int guestCount);



    }
}
