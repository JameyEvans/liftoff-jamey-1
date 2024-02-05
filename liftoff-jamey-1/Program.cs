/*using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Data;

//namespace liftoff_jamey_1;

//public class Program
//{
    //public static void Main(string[] args)
    //{
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
        builder.Services.AddControllersWithViews();

        //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        
        builder.Services.AddDbContext<BookClubDbContext>(options =>
            options.UseSqlite(builder.Configuration
            .GetConnectionString("BookClubConnectionString")));
        
        //builder.Services.AddRazorPages();
        
        //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
       
        //builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            //app.UseMigrationsEndPoint();
        //}
        //else
        //{
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    //}
//}*/


using liftoff_jamey_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

/*builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
		   .AddEntityFrameworkStores<BookClubDbContext>();*/


IConfiguration configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();

builder.Services.AddDbContext<BookClubDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    {
	    app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();
        app.MapControllers();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();








/*public void ConfigureServices(IServiceCollection services)
{
	IConfiguration configuration = new ConfigurationBuilder()
	.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
	.AddJsonFile("appsettings.json")
	.Build();

	services.AddDbContext<BookClubDbContext>(options =>
		options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

	// Setup dependency injection
	var serviceProvider = new ServiceCollection()
	.AddDbContext<BookClubDbContext>(options =>
	options.UseSqlite(configuration.GetConnectionString("DefaultConnection")))
	.BuildServiceProvider();

	var builder = WebApplication.CreateBuilder();*/