using HOTELBOOKING.Application.Dtos.Role.Response;
using HOTELBOOKING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<IEnumerable<GetAllRoleResponseDto>> GetAllRoles(string storedProcedure);
    }
}
