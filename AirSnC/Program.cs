using AirSnC.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore; 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//dependency injection
builder.Services.AddDbContext<SignInDbContext>(Options=>Options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
builder.Services.AddDbContext<ProductsDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "LogIn",
                pattern: "LogIn",
                defaults: new { controller = "SignInsController", action = "Create" });
//app.MapControllerRoute(name: "ProductView",
//                pattern: "ProductView",
//                defaults: new { controller = "HomeController", action = "ProductView" });

app.Run();
