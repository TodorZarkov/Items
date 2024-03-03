namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using System;
	using System.Threading.Tasks;

	public class FileIdentifierService : IFileIdentifierService
	{
		private readonly ItemsDbContext dbContext;
		public FileIdentifierService(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}


		//todo: must perform fast. to CACHE the FileIdentifiers table in the ram!!!
		public async Task<bool> CanAccess(Guid userId, Guid fileId)
		{
			FileIdentifier? fi = await dbContext.FileIdentifiers
				.FindAsync(fileId);
			if (fi == null)
			{
				return false;
			}

			if (!fi.IsPublic)
			{
				if (fi.OwnerId != userId)
				{
					return false;
				}
			}

			return true;
		}

	}
}
