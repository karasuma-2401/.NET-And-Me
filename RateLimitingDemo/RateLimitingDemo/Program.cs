using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRateLimiter(RateLimitingOptions =>
{
    RateLimitingOptions.AddConcurrencyLimiter("ConcurrencyLimiter", options =>
        {
            options.PermitLimit = 1;
            options.QueueLimit = 1;
            options.QueueProcessingOrder = QueueProcessingOrder.NewestFirst;
        })
        .AddFixedWindowLimiter("FixedWindowLimiter", options =>
        {
            options.PermitLimit = 5;
            options.QueueLimit = 10;
            options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            options.AutoReplenishment = true;
            options.Window = TimeSpan.FromMinutes(5);
        });
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

app.UseRateLimiter();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();