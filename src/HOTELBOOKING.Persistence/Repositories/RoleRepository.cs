using Dapper;
using HOTELBOOKING.Application.Dtos.Role.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Persistence.Context;
using System.Data;

namespace HOTELBOOKING.Persistence.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllRoleResponseDto>> GetAllRoles(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var roles = await connection.QueryAsync<GetAllRoleResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return roles;
        }
    }
}
