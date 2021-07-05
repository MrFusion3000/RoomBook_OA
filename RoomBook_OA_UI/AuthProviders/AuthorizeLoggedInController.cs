//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;

//namespace RoomBook_OA_UI.AuthProviders
//{
//    public class AuthorizeLoggedInController : IAuthorizationRequirement
//    {
//        public AuthorizeLoggedInController()
//        {

//        }
//    }

//    public class LoggedIn : AuthorizationHandler<AuthorizeLoggedInController>
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private ISession Session => _httpContextAccessor.HttpContext.Session;
//        public LoggedIn(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }

//        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
//            AuthorizeLoggedInController requirement)
//        {

//            var timeUserId = Session.GetString("userID");
//            if (!string.IsNullOrEmpty(timeUserId))
//            {
//                context.Succeed(requirement);
//            }
//            return Task.CompletedTask;
//        }
//    }
//}
