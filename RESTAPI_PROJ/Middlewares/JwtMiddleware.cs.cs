using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using RESTAPI_PROJ.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace RESTAPI_PROJ.Middlewares
{
    public class JwtMiddleware : IMiddleware
    {
        private readonly JwtSecurityTokenHandlerWrapper _jwtSecurityTokenHandler;

        public JwtMiddleware(JwtSecurityTokenHandlerWrapper jwtSecurityTokenHandler)
        {
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Get the token from the Authorization header
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (!token.IsNullOrEmpty())
            {

                try
                {
                    // Verify the token using the JwtSecurityTokenHandlerWrapper
                    var claimsPrincipal = _jwtSecurityTokenHandler.ValidateJwtToken(token);

                    // Extract the user ID from the token
                    var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    // Store the user ID in the HttpContext items for later use
                    context.Items["UserId"] = userId;

                    // You can also do the for same other key which you have in JWT token.
                }
                catch (Exception)
                {
                    // If the token is invalid, throw an exception
                    //context.Result = new UnauthorizedResult();
                    context.Response.StatusCode = 401;
                }


            }
            // Continue processing the request
            await next(context);
        }
    }
    
}
