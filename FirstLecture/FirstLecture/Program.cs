using FirstLecture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AddTransient ==> call a least 1 every change
// builder.Services.AddTransient<IRepository>(services => new MyRepository(services.GetRequiredService<ILogger<MyRepository>>()));

//builder.Services.AddScoped<IRepository>(services => new MyRepository(services.GetRequiredService<ILogger<MyRepository>>()));

builder.Services.AddSingleton<IRepository>(services => new MyRepository(services.GetRequiredService<ILogger<MyRepository>>()));

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

// middleware
app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();