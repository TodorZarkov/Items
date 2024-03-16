namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Threading.Tasks;

	public class FileIdentifierService : IFileIdentifierService
	{
		private readonly ItemsDbContext dbContext;
		public FileIdentifierService(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}


		//todo: must perform fast. To CACHE the FileIdentifiers table in the ram!!!
		public async Task<bool> CanAccessAsync(Guid userId, Guid fileId)
		{
			FileIdentifier? fi = await dbContext.FileIdentifiers
				.FindAsync(fileId);
			if (fi == null)
			{
				return false;
			}

			if (!fi.IsPublic)
			{
				if (fi.OwnerId != userId && fi.CoOwnerId != userId)
				{
					return false;
				}
			}

			return true;
		}

		public async Task<IEnumerable<Guid>> PublicFilesByItemIdAsync(Guid itemId)
		{
			Guid[] itemImageIds = await dbContext.FileIdentifiers
				.AsNoTracking()
				.Where(fi => fi.ItemId == itemId)
				.Where(fi => fi.IsPublic)
				.Select(fi => fi.FileId)
				.ToArrayAsync();

			return itemImageIds;
		}

	}
}
