using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace RoomBook_OA_UI.AuthProviders
{
    public class AuthorizeLoggedInController : IAuthorizationRequirement
    {
        public AuthorizeLoggedInController()
        {

        }
    }

    public class LoggedIn : AuthorizationHandler<AuthorizeLoggedInController>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public LoggedIn(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            AuthorizeLoggedInController requirement)
        {

            var UserID = _session.GetString("userID");
            if (!string.IsNullOrEmpty(UserID))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
