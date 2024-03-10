namespace Items.Services.Data
{
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.File;
	using Microsoft.Extensions.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class InNetworkFileService : IFileService
	{
		private readonly IConfiguration configuration;


		public InNetworkFileService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public async Task<Guid> AddAsync(FileServiceModel fileModel)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Guid>> AddManyAsync(IEnumerable<FileServiceModel> fileModels)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Guid fileId)
		{
			throw new NotImplementedException();
		}

		public Task<long> DeleteManyAsync(IEnumerable<Guid> ids)
		{
			throw new NotImplementedException();
		}

		public Task<FileServiceModel> GetAsync(Guid fileId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<FileServiceModel>> GetManyAsync(IEnumerable<Guid> fileIds)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetPath(Guid fileId)
		{
			throw new NotImplementedException();
		}

		public Task ModifyAsync(Guid fileId, FileServiceModel fileModel)
		{
			throw new NotImplementedException();
		}

		public Task<int> SaveChangesAsync()
		{
			throw new NotImplementedException();
		}
	}
}
