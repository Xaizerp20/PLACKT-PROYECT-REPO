
using System.Threading.Tasks;
using manageRegistersApp.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;



namespace manageRegistersApp.Services
{
    public class AuthMiddleware : IMiddleware
    {

        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        private readonly AuthenticationStateProvider _authenticationStateProvider;
   


        public AuthMiddleware( ProtectedSessionStorage sessionStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _sessionStorage = sessionStorage;
            _authenticationStateProvider = authenticationStateProvider;
     
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            await next(context);

   
            

        }
    }
}




