using System.Globalization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

IFormatProvider? enUS = new CultureInfo("en-US");
IdentityModelEventSource.ShowPII = true;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
        options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://mysso-server.com",
                ValidAudience = "http://localhost:5074/",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345")),
            };
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {

                    }
                    return Task.CompletedTask;
                }
            };
        });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Policy1", policy => policy.RequireRole("Role1").RequireRole("Role2")
        .RequireClaim("client-id", "client1", "client2", "client3")
        .RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth")
        .RequireAssertion(context => context.User.Identity?.Name?.StartsWith("Le ", StringComparison.OrdinalIgnoreCase) ?? false)
        .RequireAssertion(context => 
            DateTime.TryParseExact(context.User.Claims.Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth").Select(c => c.Value).FirstOrDefault(), "yyyy-MM-dd", enUS, DateTimeStyles.None, out DateTime dob)
            && dob.Year < 2000)
    );
    options.AddPolicy("Policy2", policy => policy.RequireRole("Role3"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();