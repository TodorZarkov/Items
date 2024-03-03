namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.File;

	public interface IFileService
	{
		Task<Guid> AddAsync(FileServiceModel fileModel);
		Task<IEnumerable<Guid>> AddManyAsync(IEnumerable<FileServiceModel> fileModels);


		Task ModifyAsync(Guid fileId, FileServiceModel fileModel);


		Task<FileServiceModel> GetAsync(Guid fileId);

		Task<IEnumerable<FileServiceModel>> GetManyAsync(IEnumerable<Guid> fileIds);


		Task DeleteAsync(Guid fileId);

		Task<long> DeleteManyAsync(IEnumerable<Guid> ids);


		Task<string?> GetPath(Guid fileId);

	}
}
