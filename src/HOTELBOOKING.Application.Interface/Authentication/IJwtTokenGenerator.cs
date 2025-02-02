using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.Interface.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
