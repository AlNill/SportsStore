using Microsoft.EntityFrameworkCore;
using SportsStore.Web.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration["Data:SportsStoreProducts:ConnectionString"];
services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
services.AddTransient<IProductRepository, EFProductRepository>();

services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "pagination",
        template: "Products/Page{productPage}",
        defaults: new { Controller = "Product", action = "List" }
        );
    routes.MapRoute(
        name: "default",
        template: "{controller=Product}/{action=List}/{id?}");
});

app.Run();
