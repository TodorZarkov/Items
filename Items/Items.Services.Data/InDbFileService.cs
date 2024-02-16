namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.File;
	using Microsoft.EntityFrameworkCore;

	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class InDbFileService : IFileService
	{
		private readonly ItemsDbContext dbContext;

		public InDbFileService(ItemsDbContext dbContext)
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

		public async Task<IEnumerable<FileServiceModel>> GetManyAsync(IEnumerable<Guid> fileIds)
		{
			var models = await dbContext.Files
				.Where(f => fileIds.Any(fid => fid == f.Id))
				.Select(f => new FileServiceModel
				{
					Bytes = f.Bytes,
					MimeType = f.MimeType,
					Name = f.Name
				})
				.ToArrayAsync();

			return models;
		}

		public async Task ModifyAsync(Guid fileId, FileServiceModel fileModel)
		{
			var file = await dbContext.Files.FirstAsync(f => f.Id == fileId);

			file.Name = fileModel.Name;
			file.Bytes = fileModel.Bytes;
			file.MimeType = fileModel.MimeType;

			await dbContext.SaveChangesAsync();
		}

		public async Task<Guid> AddAsync(FileServiceModel fileModel)
		{
			var file = new File
			{
				Bytes = fileModel.Bytes,
				MimeType = fileModel.MimeType,
				Name = fileModel.Name
			};

			await dbContext.Files.AddAsync(file);

			return file.Id;
		}

		public Task<string> GetPath(Guid fileId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Guid>> AddManyAsync(IEnumerable<FileServiceModel> fileModels)
		{
			throw new NotImplementedException();
		}

		public Task<long> DeleteManyAsync(IEnumerable<Guid> ids)
		{
			throw new NotImplementedException();
		}
	}
}
