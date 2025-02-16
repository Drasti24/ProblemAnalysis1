//DRASTI PATEL (#8839416)
//PROBLEM ANALYSIS #1
//FEBRUARY 16, 2025

using DatePickerHint.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//add services to the container.
builder.Services.AddControllersWithViews();

//configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//set up middleware for handling requests and responses
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

//configure default routes to map controller actions to URL patterns.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");       //default to 'Student' controller, 'Index' action.

//run the application
app.Run();
