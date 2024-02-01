namespace Items.Services.Data
{
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.File;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class InNetworkFileService : IFileService
	{
		public Task<Guid> AddAsync(FileServiceModel fileModel)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Guid fileId)
		{
			throw new NotImplementedException();
		}

		public Task<FileServiceModel> GetAsync(Guid fileId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<FileServiceModel>> GetAsync(IEnumerable<Guid> fileIds)
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
	}
}
