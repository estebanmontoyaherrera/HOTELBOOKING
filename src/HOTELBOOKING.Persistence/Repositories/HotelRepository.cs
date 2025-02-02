using Dapper;
using HOTELBOOKING.Application.Dtos.Hotel.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Persistence.Context;
using System.Data;

namespace HOTELBOOKING.Persistence.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllHotelResponseDto>> GetAllHotels(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var hotels = await connection.QueryAsync<GetAllHotelResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return hotels;
        }
    }

}
