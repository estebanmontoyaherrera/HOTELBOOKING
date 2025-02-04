using HOTELBOOKING.Application.Dtos.Hotel.Response;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<IEnumerable<GetAllHotelResponseDto>> GetAllHotels(string storedProcedure);
        Task<Hotel> RegisterHotel(Hotel hotel);
        Task RegisterRoom(Room room);
    }

}
