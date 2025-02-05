using HOTELBOOKING.Application.Dtos.Hotel.Response;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<IEnumerable<GetAllHotelResponseDto>> GetAllHotels(string storedProcedure);
        Task<Hotel> GetHotelById(int hotelId);
        Task<IEnumerable<Room>> GetRoomsByHotelId(int hotelId);

        Task<IEnumerable<Hotel>> GetHotelsRoomsByCityId(int cityId, DateTime checkIn, DateTime checkOut, int capacity);


        Task<Hotel> RegisterHotel(Hotel hotel);
        Task RegisterRoom(Room room);
    }

}