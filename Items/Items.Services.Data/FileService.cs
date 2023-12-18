namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.File;
	using Microsoft.EntityFrameworkCore;

	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class FileService : IFileService
	{
		private readonly ItemsDbContext dbContext;

		public FileService(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task DeleteAsync(Guid fileId)
		{
			File file = await dbContext.Files.FirstAsync(f => f.Id == fileId);
			dbContext.Files.Remove(file);

			await dbContext.SaveChangesAsync();
		}

		public async Task<FileServiceModel> GetAsync(Guid fileId)
		{
			var file = await dbContext.Files.FirstAsync(f => f.Id == fileId);

			var model = new FileServiceModel
			{
				Bytes = file.Bytes,
				MimeType = file.MimeType,
				Name = file.Name
			};

			return model;
		}

		public async Task<IEnumerable<FileServiceModel>> GetAsync(IEnumerable<Guid> fileIds)
		{
			throw new NotImplementedException();
		}

		public Task ModifyAsync(Guid fileId, FileServiceModel fileModel)
		{
			throw new NotImplementedException();
		}

		public Task<Guid> SaveAsync(FileServiceModel fileModel)
		{
			throw new NotImplementedException();
		}
	}
}
