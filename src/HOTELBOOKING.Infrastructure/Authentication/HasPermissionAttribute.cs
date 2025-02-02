

using Microsoft.AspNetCore.Authorization;

namespace HOTELBOOKING.Infrastructure.Authentication
{
    public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(Permission permission) : base(policy: permission.ToString())
        {

        }
    }
}
