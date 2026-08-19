using Ghtk.Authorization;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddAuthentication("X-Client-Source").AddXClientSource(options =>
{
    options.ClientValidator = (clientSource, token, principal) => true;
    options.IssuerSigningKey = builder.Configuration["IssuerSigningKey"] ?? "";
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();