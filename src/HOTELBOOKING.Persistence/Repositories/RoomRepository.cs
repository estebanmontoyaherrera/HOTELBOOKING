using Dapper;
using HOTELBOOKING.Application.Dtos.Room.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Persistence.Context;
using System.Data;

namespace HOTELBOOKING.Persistence.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllRoomResponseDto>> GetAllRooms(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var rooms = await connection.QueryAsync<GetAllRoomResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return rooms;
        }

      



    }
}
