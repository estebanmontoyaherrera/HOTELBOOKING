using HOTELBOOKING.Application.Dtos.User.Response;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<GetAllUserResponseDto>> GetAllUsers(string storedProcedure);
        Task<User> GetUserByEmailAsync(string procedure, string email);
    }
}
