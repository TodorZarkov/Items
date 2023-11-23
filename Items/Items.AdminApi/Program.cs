namespace Items.AdminApi
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Common;
	using Items.Services.Common.Interfaces;
	using Items.Services.Data;
	using Items.Services.Data.Interfaces;

	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.IdentityModel.Tokens;

	using System.Text;
	using System.Text.Json;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllers();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: "CORSPolicy", p =>
				{
					p.WithOrigins("http://127.0.0.1:5173"
									, "https://127.0.0.1:5173"
									, "https://localhost:7229");
				});
			});


			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string DefaultConnection not found.");
			builder.Services.AddDbContext<ItemsDbContext>(options =>
			{
				options.UseSqlServer(connectionString, x => x.UseNetTopologySuite());
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
					options.SaveToken = builder.Configuration.GetValue<bool>("Jwt:SaveToken");
					options.RequireHttpsMetadata = builder.Configuration.GetValue<bool>("Jwt:RequireHttpsMetadata");
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = builder.Configuration.GetValue<bool>("Jwt:ValidateIssuer"),
						ValidateAudience = builder.Configuration.GetValue<bool>("Jwt:ValidateAudience"),
						ValidAudience = builder.Configuration["Jwt:Audience"],
						ValidIssuer = builder.Configuration["Jwt:Issuer"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
						ValidateIssuerSigningKey = true,
						ValidateLifetime = false,

					};
					options.Events = new JwtBearerEvents()
					{
						OnChallenge = context =>
						{
							context.HandleResponse();
							context.Response.StatusCode = StatusCodes.Status401Unauthorized;
							context.Response.ContentType = "application/json";

							// Ensure we always have an error and error description.
							if (string.IsNullOrEmpty(context.Error))
								context.Error = "invalid_token";
							if (string.IsNullOrEmpty(context.ErrorDescription))
								context.ErrorDescription = "This request requires a valid JWT access token to be provided";

							// Add some extra context for expired tokens.
							if (context.AuthenticateFailure != null && context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException))
							{
								var authenticationException = context.AuthenticateFailure as SecurityTokenExpiredException;
								context.Response.Headers.Add("x-token-expired", authenticationException.Expires.ToString("o"));
								context.ErrorDescription = $"The token expired on {authenticationException.Expires.ToString("o")}";
							}

							return context.Response.WriteAsync(JsonSerializer.Serialize(new
							{
								error = context.Error,
								error_description = context.ErrorDescription
							}));
						}
					};
				});
			builder.Services
				.AddAuthorization();


			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			builder.Services.AddScoped<IDateTimeProvider, DateTimeUtcProvider>();
			builder.Services.AddScoped<ITokenAuthService, JwtAuthService>();
			builder.Services.AddScoped<IUserService, UserService>();


			var app = builder.Build();



			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseCors("CORSPolicy");
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}