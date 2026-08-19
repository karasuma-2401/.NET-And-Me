using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ghtk.Authorization;

public static class XClientSourceAuthenticationHandlerExtensions
{
    public static AuthenticationBuilder AddXClientSource(this AuthenticationBuilder builder, Action<XClientSourceAuthenticationHandlerOptions> configureOptions)
    {
        return builder.AddScheme<XClientSourceAuthenticationHandlerOptions, XClientSourceAuthenticationHandler>("X-Client-Source", configureOptions);
    }
}