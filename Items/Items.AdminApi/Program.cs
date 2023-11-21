namespace Items.AdminApi
{
	using Items.Data;
	using Items.Data.Models;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.IdentityModel.Tokens;
	using System.Text;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string DefaultConnection not found.");
			builder.Services.AddDbContext<ItemsDbContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});

			builder.Services
				.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
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
				.AddEntityFrameworkStores<ItemsDbContext>()
				.AddDefaultTokenProviders();

			builder.Services
				.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.SaveToken = true;
					options.RequireHttpsMetadata = false;
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = builder.Configuration.GetValue<bool>("Jwt:ValidateIssuer"),
						ValidateAudience = builder.Configuration.GetValue<bool>("Jwt:ValidateAudience"),
						ValidAudience = builder.Configuration["Jwt:Audience"],
						ValidIssuer = builder.Configuration["Jwt:Issuer"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
					};
				});

			builder.Services.AddControllers();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: "CORSPolicy", p =>
				{
					p.WithOrigins("http://127.0.0.1:5173"
									, "https://127.0.0.1:5173");
				});
			});

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();



			var app = builder.Build();



			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseCors("CORSPolicy");
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}