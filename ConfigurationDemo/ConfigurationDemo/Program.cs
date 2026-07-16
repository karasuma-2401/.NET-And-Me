using ConfigurationDemo.ConfigModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.AddJsonFile("my-appsettings.json", optional: false, reloadOnChange: false);
builder.Configuration.AddJsonFile($"my-appsettings{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: false);

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

var host = builder.Build();

// Configure the HTTP request pipeline.
if (!host.Environment.IsDevelopment())
{
    host.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    host.UseHsts();
}

host.UseHttpsRedirection();
host.UseRouting();

host.UseAuthorization();

host.MapStaticAssets();

host.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
    
var t = host.RunAsync();


Console.WriteLine("Press ENTER to exit...");
Console.ReadLine();

await host.StopAsync();
await t;