namespace Items.Web
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Common;
	using Items.Services.Common.Interfaces;
	using Items.Services.Data;
	using Items.Services.Data.Interfaces;
	using Items.Services.Mapping;
	using Items.Web.Infrastructure.ModelBinders;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.WebEncoders;

	using System.Text.Unicode;

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

			builder.Services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile<ItemsProfile>();
			});

			builder.Services.Configure<WebEncoderOptions>(options =>
			{
				options.TextEncoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All);

            });

			builder.Services.AddControllersWithViews(opt =>
				{
					opt.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
					opt.ModelBinderProviders.Insert(0, new StringModelBinderProvider());
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

			WebApplication app = builder.Build();

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

			app.Use(async (ctx, next) =>
			{
				await next.Invoke();
			});

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