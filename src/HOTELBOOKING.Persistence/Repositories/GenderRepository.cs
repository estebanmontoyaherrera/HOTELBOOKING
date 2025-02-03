using Dapper;
using HOTELBOOKING.Application.Dtos.Gender;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Persistence.Context;
using System.Data;

namespace HOTELBOOKING.Persistence.Repositories
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        private readonly ApplicationDbContext _context;
        public GenderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllGenderResponseDto>> GetAllGenders(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var genders = await connection.QueryAsync<GetAllGenderResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return genders;
        }
    }

}
