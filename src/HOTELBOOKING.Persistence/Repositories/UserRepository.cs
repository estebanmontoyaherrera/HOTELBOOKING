using Dapper;
using HOTELBOOKING.Application.Dtos.User.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Persistence.Context;
using System.Data;

namespace HOTELBOOKING.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllUserResponseDto>> GetAllUsers(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var users = await connection.QueryAsync<GetAllUserResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return users;
        }

        public async Task<User> GetUserByEmailAsync(string procedure, string email)
        {
            using var connection = _context.CreateConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Email", email);

            var user = await connection
                    .QuerySingleOrDefaultAsync<User>(procedure, param: parameters, commandType: CommandType.StoredProcedure);
            return user;
        }
    }
}
