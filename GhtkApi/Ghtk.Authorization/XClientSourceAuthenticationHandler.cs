using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ghtk.Authorization;

public class XClientSourceAuthenticationHandler(IOptionsMonitor<XClientSourceAuthenticationHandlerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock): 
    AuthenticationHandler<XClientSourceAuthenticationHandlerOptions>(options, logger, encoder, clock)
{
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var clientSource = Context.Request.Headers["X-Client-Source"];
        var tokenHeader = Context.Request.Headers["Token"];
        if (clientSource.Count == 0)
        {
            return AuthenticateResult.Fail("Missing X-Client-Source header");
        }
        // if (tokenHeader.Count == 0)
        // {
        //     return AuthenticateResult.Fail("Missing Token header");
        // }

        var clientSourceValue = clientSource.FirstOrDefault();
        if (clientSourceValue == null)
        {
            return AuthenticateResult.Fail("Missing X-Client-Source header");
        }
        var tokenValue = tokenHeader.FirstOrDefault();
        
        if (!Options.ClientSourceValidator(clientSourceValue))
        {
            return AuthenticateResult.Fail("Invalid X-Client-Source");
        }

        var identity = new ClaimsIdentity(Scheme.Name);
        identity.AddClaim(new Claim(ClaimTypes.Name, clientSourceValue));
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return AuthenticateResult.Success(ticket);
    }
}