using Dapper;
using HOTELBOOKING.Persistence.Context;

namespace HOTELBOOKING.Infrastructure.Authentication
{
    public class PermissionService : IPermissionService
    {
        private readonly ApplicationDbContext _context;

        public PermissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HashSet<string>> GetPermissionAsync(int userId)
        {
            using var connection = _context.CreateConnection;

            var query = @"
            SELECT 
                P.NAME
            FROM USERS U
            INNER JOIN ROLES R ON U.ROLEID = R.ROLEID
            INNER JOIN ROLEPERMISSIONS RP ON R.ROLEID = RP.ROLEID
            INNER JOIN PERMISSIONS P ON RP.PERMISSIONID = P.PERMISSIONID
            WHERE U.USERID = @USERID";

            var parameters = new DynamicParameters();
            parameters.Add("UserId", userId);

            var result = await connection.QueryAsync<string>(query, parameters);

            var permissions = new HashSet<string>(result);

            return permissions;
        }
    }
}
