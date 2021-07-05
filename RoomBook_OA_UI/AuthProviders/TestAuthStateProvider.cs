//using Microsoft.AspNetCore.Components.Authorization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace RoomBook_OA_UI.AuthProviders
//{
//    public class TestAuthStateProvider : AuthenticationStateProvider
//    {
//        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//        {
//            await Task.Delay(500);
//            var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.Name, "John Doe"),
//                new Claim(ClaimTypes.Role, "Administrator")
//            };

//            var anonymous = new ClaimsIdentity(claims, "testAuthType");
//            //var anonymous = new ClaimsIdentity();

//            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
//        }
//    }
//}
