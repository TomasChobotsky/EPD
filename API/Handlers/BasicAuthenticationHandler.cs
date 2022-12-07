using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly EpdContext _context;
        
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options , ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, EpdContext context) : base(options, logger, encoder, clock)
        {
            _context = context;
        }
        
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization")) 
                return AuthenticateResult.Fail("Missing Authorization Header");

            try
            {
                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];
            
                User user = _context.Users.FirstOrDefault(user => user.Username == username && user.Password == password);

                if (user == null)
                    return AuthenticateResult.Fail("Invalid Username or Password");
                else
                {
                    var claims = new[] {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username)
                    };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    
                    return AuthenticateResult.Success(ticket);
                }
            }
            catch (Exception e)
            {
                return AuthenticateResult.Fail(e.Message);
            }
        }
    }
}