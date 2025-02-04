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

        public async Task<Hotel> RegisterHotel(Hotel hotel)
        {
            var connection = _context.CreateConnection;
            var sql = @"INSERT INTO HOTELS (NAME, ADDRESS, CITYID, COMMISSIONRATE, STATE, AUDITCREATEDATE)
                VALUES (@Name, @Address, @CityId, @CommissionRate, @State, @AuditCreateDate);
                SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", hotel.Name);
            parameters.Add("Address", hotel.Address);
            parameters.Add("CityId", hotel.CityId);
            parameters.Add("CommissionRate", hotel.CommissionRate);
            parameters.Add("State", 1); 
            parameters.Add("AuditCreateDate", DateTime.Now);

            var hotelId = await connection.QuerySingleOrDefaultAsync<int>(sql, param: parameters);
            hotel.HotelId = hotelId;
            return hotel;
        }

        public async Task RegisterRoom(Room room)
        {
            var connection = _context.CreateConnection;
            var sql = @"INSERT INTO ROOMS (HOTELID, ROOMTYPEID, CAPACITY, BASECOST, TAXES, LOCATION, STATE, AUDITCREATEDATE)
                VALUES (@HotelId, @RoomTypeId, @Capacity, @BaseCost, @Taxes, @Location, @State, @AuditCreateDate)";

            var parameters = new DynamicParameters();
            parameters.Add("HotelId", room.HotelId);
            parameters.Add("RoomTypeId", room.RoomTypeId);
            parameters.Add("Capacity", room.Capacity);
            parameters.Add("BaseCost", room.BaseCost);
            parameters.Add("Taxes", room.Taxes);
            parameters.Add("Location", room.Location);
            parameters.Add("State", 1); // Estado activo por defecto
            parameters.Add("AuditCreateDate", DateTime.Now);

            await connection.ExecuteAsync(sql, param: parameters);
        }


    }

}
