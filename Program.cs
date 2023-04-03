using ShopProject.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IAllCars, CarRepository>();
//builder.Services.AddTransient<ICarCategory, CarCategoryRepository>();
//builder.Services.AddTransient<IAllOrders, OrdersRepository>();
//builder.Services.AddTransient<IOrderDetails, OrderDetailsRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(name: "cars",
    pattern: "Cars/ListCars/{category?}");

app.MapControllerRoute(name: "orders",
    pattern: "Order/AddPersonInfoToOrder/{carName?}/{carId?}",
    defaults: new { controller = "Order", action = "AddPersonInfoToOrder" });

app.Run();
