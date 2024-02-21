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
			await dbContext.SaveChangesAsync();

			return file.Id;
		}

		public Task<string> GetPath(Guid fileId)
		{
			return Task.FromResult(string.Empty);
		}

		public async Task<IEnumerable<Guid>> AddManyAsync(IEnumerable<FileServiceModel> fileModels)
		{
			List<Guid> result = new List<Guid>() ;
			List<File> files = new List<File>();
			foreach(var fileModel in fileModels)
			{
				File file = new File()
				{
					Id = Guid.NewGuid(),
					Name = fileModel.Name,
					Bytes = fileModel.Bytes,
					MimeType = fileModel.MimeType
				};
				files.Add(file);
				result.Add(file.Id);
			}
			await dbContext.Files.AddRangeAsync(files);
			await dbContext.SaveChangesAsync();

			return result;
		}

		public async Task<long> DeleteManyAsync(IEnumerable<Guid> ids)
		{
			File[] files = await dbContext.Files
				.Where(f => ids.Contains(f.Id))
				.ToArrayAsync();
			dbContext.RemoveRange(files);

			await dbContext.SaveChangesAsync();

			return files.Length;
		}
	}
}
