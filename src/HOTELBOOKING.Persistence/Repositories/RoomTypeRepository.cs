using Dapper;
using HOTELBOOKING.Application.Dtos.RoomType.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Persistence.Context;
using System.Data;

namespace HOTELBOOKING.Persistence.Repositories
{
    public class RoomTypeRepository : GenericRepository<RoomType>, IRoomTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllRoomTypeResponseDto>> GetAllRoomTypes(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var roomTypes = await connection.QueryAsync<GetAllRoomTypeResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return roomTypes;
        }
    }

}
