using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsStore.Web.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration["Data:SportsStoreProducts:ConnectionString"];
services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

var identityConnectionString = builder.Configuration["Data:SportsStoreIdentity:ConnectionString"];
services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(identityConnectionString));
services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();


services.AddTransient<IProductRepository, EFProductRepository>();
services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddTransient<IOrderRepository, EFOrderRepository>();

services.AddMemoryCache();
services.AddSession();
services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseMvc(routes =>
{
    routes.MapRoute(
     name: null,
     template: "{category}/Page{productPage:int}",
     defaults: new { Controller = "Product", action = "List"}
     );
    routes.MapRoute(
     name: null,
     template: "Page{productPage:int}",
     defaults: new { Controller = "Product", action = "List", productPage = 1 }
     );
    routes.MapRoute(
     name: null,
     template: "{category}",
     defaults: new { Controller = "Product", action = "List", productPage = 1 }
     );
    routes.MapRoute(
     name: null,
     template: "",
     defaults: new { Controller = "Product", action = "List", productPage = 1 }
     );
    routes.MapRoute(
        name: null,
        template: "{controller}/{action}/{id?}");
});

app.Run();
