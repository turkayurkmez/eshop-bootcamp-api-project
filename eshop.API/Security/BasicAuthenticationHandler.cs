using eshop.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace eshop.API.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOption>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOption> monitor,
                                          ILoggerFactory factory,
                                          UrlEncoder urlEncoder,
                                          ISystemClock clock) : base(monitor, factory, urlEncoder, clock)
        {

        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //1. Gelen talepte "Authorization" ifadesi var mı?
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //2. Bu  "Authorization" ifadesinin değeri okunabililiyor mu 
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //3. Okunan değerin şema bilgisi Basic mi?
            if (!headerValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //Basic turkay:123
            byte[] incomingEncodedData = Convert.FromBase64String(headerValue.Parameter);
            string incomingText = Encoding.UTF8.GetString(incomingEncodedData);
            string username = incomingText.Split(':')[0];
            string password = incomingText.Split(':')[1];

            var user = new UserService().IsValid(username, password);
            if (user == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Username or password invalid"));
            }

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.Role),
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            AuthenticationTicket ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
