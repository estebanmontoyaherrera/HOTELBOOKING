using HOTELBOOKING.Application.Dtos.Room.Response;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        
        Task<IEnumerable<GetAllRoomResponseDto>> GetAllRooms(string storedProcedure);
    }
}
