namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.File;
	using Microsoft.Extensions.FileProviders;

	public interface IFileService
	{
		Task<Guid> AddAsync(FileServiceModel fileModel);

		Task ModifyAsync(Guid fileId, FileServiceModel fileModel);

		Task<FileServiceModel> GetAsync(Guid fileId);

		Task<IEnumerable<FileServiceModel>> GetAsync(IEnumerable<Guid> fileIds);

		Task DeleteAsync(Guid fileId);

		Task<String> GetPath(Guid fileId);

	}
}
