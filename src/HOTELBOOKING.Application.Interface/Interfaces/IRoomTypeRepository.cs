using HOTELBOOKING.Application.Dtos.RoomType.Response;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IRoomTypeRepository : IGenericRepository<RoomType>
    {
        Task<IEnumerable<GetAllRoomTypeResponseDto>> GetAllRoomTypes(string storedProcedure);
    }

}
