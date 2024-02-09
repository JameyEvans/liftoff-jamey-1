using liftoff_jamey_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using liftoff_jamey_1.Areas.Identity.Data;



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityDbContextConnection' not found.");
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
		   .AddEntityFrameworkStores<ApplicationDbContext>();


IConfiguration configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
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

