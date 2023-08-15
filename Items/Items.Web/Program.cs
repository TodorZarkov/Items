namespace Items.Web
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Common;
	using Items.Services.Common.Interfaces;
	using Items.Services.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ModelBinder;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			var connectionString = 
				builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			builder.Services.AddDbContext<ItemsDbContext>(options =>
			{
				options.UseSqlServer(connectionString, x => x.UseNetTopologySuite());
            }); 

              
			builder.Services
				.AddDefaultIdentity<ApplicationUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount	
					= builder.Configuration.GetValue<bool>("SignIn:RequireConfirmedAccount");

				options.Password.RequireNonAlphanumeric 
					= builder.Configuration.GetValue<bool>("Password:RequireNonAlphanumeric");

				options.Password.RequireUppercase		
					= builder.Configuration.GetValue<bool>("Password:RequireUppercase");

				options.Password.RequireLowercase		
					= builder.Configuration.GetValue<bool>("Password:RequireLowercase");

				options.Password.RequireDigit			
					= builder.Configuration.GetValue<bool>("Password:RequireDigit");

				options.Password.RequiredLength			
					= builder.Configuration.GetValue<int>("Password:RequiredLength");

				options.User.RequireUniqueEmail			
					= builder.Configuration.GetValue<bool>("User:RequireUniqueEmail");

				options.Lockout.DefaultLockoutTimeSpan 
					= TimeSpan.FromMinutes(builder.Configuration.GetValue<int>("Lockout:DefaultLockoutTimeSpan"));

				options.Lockout.MaxFailedAccessAttempts 
					= builder.Configuration.GetValue<int>("Lockout:MaxFailedAccessAttempts");
			})
				.AddEntityFrameworkStores<ItemsDbContext>();

			builder.Services.AddControllersWithViews(opt =>
				{
					opt.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
				});

			builder.Services.AddScoped<IItemService, ItemService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<ILocationService, LocationService>();
			builder.Services.AddScoped<IPlaceService, PlaceService>();
			builder.Services.AddScoped<IOfferService, OfferService>();
			builder.Services.AddScoped<IContractService, ContractService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<ICurrencyService, CurrencyService>();
			builder.Services.AddScoped<IUnitService, UnitService>();

			builder.Services.AddScoped<IHelper, Helper>();
			builder.Services.AddScoped<IDateTimeProvider, DateTimeUtcProvider>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
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

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}
	}
}