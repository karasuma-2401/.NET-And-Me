var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// handle middleware
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// URL that is processed from top to bottom

// set the rules 
app.MapControllerRoute(
    name: "default",
    // map with pattern to find 
    pattern: "{controller=Home}/{action=Privacy}/{id?}")
    .WithStaticAssets();

// // new rules 
// app.MapControllerRoute(
//         name: "product-details",
//         // map with pattern to find 
//         pattern: "p/{id}",
//         defaults: new { controller = "product", action = "Details" })
//     .WithStaticAssets();

// show collections
app.MapControllerRoute(
        name: "collection",
        // map with pattern to find 
        pattern: "c/{id=1}",
        defaults: new { controller = "Collection", action = "Index" })
    .WithStaticAssets();


app.Run();
