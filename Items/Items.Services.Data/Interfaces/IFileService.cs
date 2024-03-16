namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.File;


	//TODO: the unity of work between the services must be observed. As long as the file service and the other data services
	//are in the same place with shared .SaveChanges() there is no problem with the unity of work.
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


		Task<int> SaveChangesAsync();

	}
}
