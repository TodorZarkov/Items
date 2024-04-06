namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.File;
	using Items.Services.Data.Models.User;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Caching.Memory;
	using System;
	using System.Net.Mime;
	using System.Threading.Tasks;

	public class UserService : IUserService
	{
		private readonly ItemsDbContext dbContext;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly IFileService fileService;

		public UserService(ItemsDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IFileService fileService)
		{
			this.dbContext = dbContext;
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.fileService = fileService;
		}
		public async Task<long> Count()
		{
			long usersCount = await dbContext.Users
				.AsNoTracking()
				.LongCountAsync(u => u.Email != null || u.UserName != null);

			return usersCount;
		}

		public async Task<ApplicationUser?> GetByEmailAsync(string email)
		{
			ApplicationUser? user = await dbContext.Users
				.FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

			return user;
		}

		public async Task<ApplicationUser?> GetByIdAsync(Guid userId)
		{
			ApplicationUser? user = await dbContext.Users.FindAsync(userId);
			return user;
		}

		public async Task<AllRoleServiceModel[]> GetRolesAsync(ApplicationUser user)
		{
			var roleIds = await dbContext.UserRoles
				.Where(ur => ur.UserId == user.Id)
				.Select(ur => ur.RoleId)
				.ToArrayAsync();
			var roles = await dbContext.Roles
				.Where(r => roleIds.Contains(r.Id))
				.Select(r => new AllRoleServiceModel
				{
					Id = r.Id,
					Name = r.Name
				})
				.ToArrayAsync();

			return roles;
		}

		public async Task<string?> GetRoleAsync(Guid roleId)
		{
			IdentityRole<Guid>? role = await dbContext.Roles
				.FindAsync(roleId);
			if (role == null)
			{
				return null;
			}

			return role.Name;
		}

		public async Task<DateTime> GetRotationItemsDateAsync(Guid userId)
		{
			DateTime date = await dbContext.Users
				.Where(u => u.Id == userId)
				.Select(u => u.RotationItemsDate)
				.FirstAsync();

			return date;
		}

		public async Task<IdentityResult> RegisterAsync(RegisterUserServiceModel model)
		{
			ApplicationUser user = new ApplicationUser
			{
				UserName = model.Email,
				NormalizedUserName = model.Email.ToUpper(),
				Email = model.Email,
				NormalizedEmail = model.Email.ToUpper(),
			};
			IdentityResult result = await userManager.CreateAsync(user, model.Password);

			return result;
		}

		public async Task<bool> RoleExistAsync(string role)
		{
			bool result = await dbContext.Roles
				.AnyAsync(r => r.NormalizedName == role.ToUpper());

			return result;
		}



		public async Task SetRotationItemsDateAsync(Guid userId, DateTime newDateTime)
		{
			dbContext.Users
				.Find(userId)!
				.RotationItemsDate = newDateTime;

			await dbContext.SaveChangesAsync();
		}

		public async Task AddProfilePictureAsync(Guid userId, IFormFile profilePicture)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				await profilePicture.CopyToAsync(memoryStream);
				ApplicationUser? user = await dbContext.Users.FindAsync(userId);

				var fileModel = new FileServiceModel
				{
					Bytes = memoryStream.ToArray(),
					MimeType = MediaTypeNames.Image.Jpeg
				};

				user!.ProfilePictureId = await fileService.AddAsync(fileModel);

				await dbContext.SaveChangesAsync();
				await fileService.SaveChangesAsync();
			}
		}

		public async Task<byte[]?> GetProfilePictureAsync(Guid userId)
		{
			ApplicationUser user = (await dbContext.Users.FindAsync(userId))!;
			Guid? userProfilePictureId = user.ProfilePictureId;
			if (userProfilePictureId != null)
			{
				FileServiceModel picture = 
					await fileService.GetAsync((Guid)user.ProfilePictureId!);
				return picture.Bytes;
			}

			return null;
		}

		public async Task DeleteProfilePictureAsync(Guid userId)
		{
			ApplicationUser user = (await dbContext.Users.FindAsync(userId))!;

			if (user.ProfilePictureId == null)
			{
				return;
			}

			await fileService.DeleteAsync((Guid)user.ProfilePictureId!);
			user.ProfilePictureId = null;

			await dbContext.SaveChangesAsync();
			await fileService.SaveChangesAsync();
		}
	}
}
